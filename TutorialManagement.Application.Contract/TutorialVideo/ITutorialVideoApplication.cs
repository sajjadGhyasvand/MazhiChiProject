using System.Collections.Generic;
using System.Threading.Tasks;
using My_Shop_Framework.Application;
using TutorialManagement.Application.Contract.IntroductionVideo;

namespace TutorialManagement.Application.Contract.TutorialVideo
{
    public interface ITutorialVideoApplication
    {
        OperationResult Create(CreateTutorialVideo command);
        OperationResult Edit(EditTutorialVideo command);
        EditTutorialVideo GetDetails(long id);
        List<TutorialVideoVideoModel> Search(TutorialVideoSearchModel searchModel);
        List<TutorialVideoVideoModel> List();
        Task<List<VideoViewDetailViewModel>> GetVideoView(long videoId);
    }
}