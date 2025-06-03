using System.Collections.Generic;
using GeneralManagement.Application.Contracts.AboutUs;
using GeneralManagement.Domain.AboutAgg;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application
{
    public class AboutUsApplication : IAboutUsApplication
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        private readonly IFileUploader _fileUploader;

        public AboutUsApplication(IAboutUsRepository aboutUsRepository, IFileUploader fileUploader)
        {
            _aboutUsRepository = aboutUsRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateAboutUs command)
        {
            var operation = new OperationResult();

            if (_aboutUsRepository.Exists(x => x.Title == command.Title && x.LanguageId == command.LanguageId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var path = $"About\\{command.Title.Slug()}\\{command.LanguageId}\\";
            var fileName = _fileUploader.FileUpload(command.Videos, path);
            var posterName = _fileUploader.FileUpload(command.Poster, path);
            var aboutUs = new AboutUs(command.Title, command.Description, command.History, command.LanguageId, command.ShortDescription, fileName,posterName);
            _aboutUsRepository.Create(aboutUs);
            _aboutUsRepository.SaveChanges();

            return operation.Success();
        }

        public OperationResult Edit(EditAboutUs command)
        {
            var operation = new OperationResult();
            var aboutUs = _aboutUsRepository.Get(command.Id);
            if (aboutUs == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_aboutUsRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var path = $"About\\{command.Title.Slug()}\\{command.LanguageId}\\";
            var fileName = _fileUploader.FileUpload(command.Videos, path);
            var posterName = _fileUploader.FileUpload(command.Poster, path);
            aboutUs.Edit(command.Title, command.Description
                , command.History, command.LanguageId, command.ShortDescription, fileName,posterName);
            _aboutUsRepository.SaveChanges();
            return operation.Success();
        }

        public EditAboutUs GetDetails(long id)
        {
            return _aboutUsRepository.GetDetails(id);
        }

        public AboutUsViewModel GetAboutId()
        {
            var aboutId = _aboutUsRepository.GetAboutId();
            if (aboutId != null)
                return aboutId;
            return new AboutUsViewModel();
        }

        public List<AboutUsViewModel> Search(AboutUsSearchModel model)
        {
            return _aboutUsRepository.Search(model);
        }
    }
}