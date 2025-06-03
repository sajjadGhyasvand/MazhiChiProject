using System.Collections.Generic;
using My_Shop_Framework.Application;
using TutorialManagement.Application.Contract.IntroductionVideo;
using TutorialManagement.Domain.IntroductionVideo.Agg;

namespace TutorialManagement.Application
{
    public class IntroductionVideoApplication:IIntroductionVideoApplication
    {
        private readonly IIntroductionVideoRepository _introductionVideoRepository;
        private readonly IFileUploader _fileUploader;

        public IntroductionVideoApplication(IIntroductionVideoRepository introductionVideoRepository, IFileUploader fileUploader)
        {
            _introductionVideoRepository = introductionVideoRepository;
            _fileUploader = fileUploader;
        }
    

        public OperationResult Create(CreateIntroductionVideo command)
        {
            var operation = new OperationResult();
            if (_introductionVideoRepository.Exists(x => x.Title == command.Title && x.LanguageId == command.LanguageId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Title.Slug();
            var picturePath = $"Introduction//{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Poster, picturePath);

            var introductionVideo = new IntroductionVideo(command.Title,command.Link,fileName,command.LanguageId);

            _introductionVideoRepository.Create(introductionVideo);
            _introductionVideoRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditIntroductionVideo command)
        {
            var operation = new OperationResult();
            var introductionVideo = _introductionVideoRepository.Get(command.Id);
            if (introductionVideo != null)
            {
                var slug = command.Title.Slug();
                var picturePath = $"Introduction//{slug}//";
                var fileName = _fileUploader.FileUpload(command.Poster, picturePath);
                introductionVideo.Edit(command.Title,command.Link, fileName, command.LanguageId);
                _introductionVideoRepository.SaveChanges();
                return operation.Success();
            }
            return operation.Failed(ApplicationMessages.RecordNotFund);
        }

        public EditIntroductionVideo GetDetails(long id)
        {
            return _introductionVideoRepository.GetDetails(id);
        }

        public List<IntroductionVideoViewModel> List()
        {
            return _introductionVideoRepository.List();
        }
    }
}