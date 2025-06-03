using System.Collections.Generic;
using My_Shop_Framework.Domain;
using TutorialManagement.Application.Contract.IntroductionVideo;

namespace TutorialManagement.Domain.IntroductionVideo.Agg
{
    public interface IIntroductionVideoRepository : IRepository<long, IntroductionVideo>
    {
        List<IntroductionVideoViewModel> List();
        EditIntroductionVideo GetDetails(long id);
    }
}