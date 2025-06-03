using System.Collections.Generic;
using System.Linq;
using My_Shop_Framework.Infrastructure;
using TutorialManagement.Application.Contract.IntroductionVideo;
using TutorialManagement.Domain.IntroductionVideo.Agg;

namespace TutorialManagement.Infrastructure.EfCore.Repository
{
    public class IntroductionVideoRepository : RepositoryBase<long,IntroductionVideo>, IIntroductionVideoRepository
    {
        private readonly TutorialContext _tutorialContext;
        public IntroductionVideoRepository(TutorialContext tutorialContext) : base(tutorialContext)
        {
            _tutorialContext = tutorialContext;
        }

        public List<IntroductionVideoViewModel> List()
        {
            return  _tutorialContext.IntroductionVideos.Select(x=> new IntroductionVideoViewModel()
            {
                LanguageId = x.LanguageId,
                Id = x.Id,
                Link = x.Link,
                Poster = x.Poster,
                Title = x.Title
            }).ToList();
        }

        public EditIntroductionVideo GetDetails(long id)
        {
            return _tutorialContext.IntroductionVideos.Select(x => new EditIntroductionVideo()
            {
                LanguageId = x.LanguageId,
                Id = x.Id,
                Link = x.Link,
                PosterStr = x.Poster,
                Title = x.Title
            }).FirstOrDefault(x=>x.Id==id);
        }
    }
}