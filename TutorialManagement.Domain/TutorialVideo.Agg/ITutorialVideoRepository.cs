using My_Shop_Framework.Domain;
using System.Collections.Generic;
using TutorialManagement.Application.Contract.IntroductionVideo;
using TutorialManagement.Application.Contract.TutorialVideo;

namespace TutorialManagement.Domain.TutorialVideo.Agg
{
    public interface ITutorialVideoRepository : IRepository<long, TutorialVideo>
    {
        List<TutorialVideoVideoModel> Search(TutorialVideoSearchModel model);
        EditTutorialVideo GetDetails(long id);
        List<TutorialVideoVideoModel> List();
    }
}