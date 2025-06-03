using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Identity;
using My_Shop_Framework.Application;
using TutorialManagement.Application.Contract.IntroductionVideo;
using TutorialManagement.Application.Contract.TutorialVideo;
using TutorialManagement.Domain.IntroductionVideo.Agg;
using TutorialManagement.Domain.TutorialVideo.Agg;
using TutorialManagement.Infrastructure.EfCore;

namespace TutorialManagement.Application
{
    public class TutorialVideoApplication : ITutorialVideoApplication
    {
        private readonly ITutorialVideoRepository _tutorialVideoRepository;
        private readonly IFileUploader _fileUploader;
        private readonly TutorialContext _tutorialContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public TutorialVideoApplication(ITutorialVideoRepository tutorialVideoRepository, IFileUploader fileUploader, TutorialContext tutorialContext, UserManager<ApplicationUser> userManager)
        {
            _tutorialVideoRepository = tutorialVideoRepository;
            _fileUploader = fileUploader;
            _tutorialContext = tutorialContext;
            _userManager = userManager;
        }

        public OperationResult Create(CreateTutorialVideo command)
        {
            var operation = new OperationResult();
            if (_tutorialVideoRepository.Exists(x => x.TitleFa == command.TitleFa))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.TitleFa.Slug();
            var picturePath = $"Tutorial//{slug}//";
            var fileName = _fileUploader.FileUpload(command.Poster, picturePath);
            var tutorialVideo = new TutorialVideo(command.LinkFa, command.LinkEn,
                command.LinkRu, command.LinkAr, fileName,command.TitleEn,command.TitleFa,command.TitleAr,command.TitleRu);
            _tutorialVideoRepository.Create(tutorialVideo);
            _tutorialVideoRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditTutorialVideo command)
        {
            var operation = new OperationResult();
            var tutorialVideo = _tutorialVideoRepository.Get(command.Id);
            if (tutorialVideo != null)
            {
                var slug = command.TitleFa.Slug();
                var picturePath = $"Introduction//{slug}\\";
                var fileName = _fileUploader.FileUpload(command.Poster, picturePath);
                tutorialVideo.Edit(command.LinkFa, command.LinkEn,
                    command.LinkRu, command.LinkAr, fileName, command.TitleEn, command.TitleFa, command.TitleAr, command.TitleRu);
                _tutorialVideoRepository.Create(tutorialVideo);
                _tutorialVideoRepository.SaveChanges();
                return operation.Success();
            }
            return operation.Failed(ApplicationMessages.RecordNotFund);
        }

        public EditTutorialVideo GetDetails(long id)
        {
            return _tutorialVideoRepository.GetDetails(id);
        }

        public async Task<List<VideoViewDetailViewModel>> GetVideoView(long videoId)
        {
            var video = GetDetails(videoId);
            List<VideoView> views = _tutorialContext.VideoViews.Where(x => x.VideoId == videoId).ToList();
            List<VideoViewDetailViewModel> VideoViews = new();
            foreach (var view in views)
            {
                var user = await _userManager.FindByIdAsync(view.UserId);
                var viewOne = new VideoViewDetailViewModel()
                {
                    FullName = $"{user.FirstName} {user.LastName}",
                    UserName = user.UserName,
                    ViewTimestamp = view.ViewTimestamp,
                };

                VideoViews.Add(viewOne);
            }
            return VideoViews;
        }

        public List<TutorialVideoVideoModel> List()
        {
            return _tutorialVideoRepository.List();
        }
        public List<TutorialVideoVideoModel> Search(TutorialVideoSearchModel searchModel)
        {
            return _tutorialVideoRepository.Search(searchModel);
        }
    }
}