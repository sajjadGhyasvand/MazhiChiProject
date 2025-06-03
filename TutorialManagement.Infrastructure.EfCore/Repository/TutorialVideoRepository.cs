using System.Collections.Generic;
using System.Linq;
using My_Shop_Framework.Infrastructure;

using TutorialManagement.Application.Contract.TutorialVideo;
using TutorialManagement.Domain.TutorialVideo.Agg;

namespace TutorialManagement.Infrastructure.EfCore.Repository
{
    public class TutorialVideoRepository : RepositoryBase<long,TutorialVideo>, ITutorialVideoRepository
    {
        private readonly TutorialContext _tutorialContext;
        public TutorialVideoRepository(TutorialContext tutorialContext) : base(tutorialContext)
        {
            _tutorialContext = tutorialContext;
        }


        public List<TutorialVideoVideoModel> Search(TutorialVideoSearchModel model)
        {
            var query = _tutorialContext.TutorialVideos.Select(x => new TutorialVideoVideoModel()
            {
                Id = x.Id,
                TitleEn = x.TitleEn,
                TitleAr = x.TitleAr,
                TitleFa = x.TitleFa,
                TitleRu = x.TitleRu,
                LinkAr = x.LinkAr,
                LinkEn = x.LinkEn,
                LinkFa = x.LinkFa,
                LinkRu = x.LinkRu,
            });
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
             return query.Where(x => x.TitleFa.Contains(model.Title)).ToList();
            }

            return query.ToList();
        }

        public EditTutorialVideo GetDetails(long id)
        {
            return _tutorialContext.TutorialVideos.Select(x => new EditTutorialVideo()
            {
                Id = x.Id,
                TitleFa = x.TitleFa ?? "",
                TitleAr = x.TitleAr ?? "",
                TitleRu = x.TitleRu ?? "",
                TitleEn = x.TitleEn ?? "",
                LinkAr = x.LinkAr ?? "",
                LinkEn = x.LinkEn ?? "",
                LinkFa = x.LinkFa ?? "",
                LinkRu = x.LinkRu ?? "",
                PosterStr = x.Poster ?? ""
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<TutorialVideoVideoModel> List()
        {
            return _tutorialContext.TutorialVideos.Select(x => new TutorialVideoVideoModel()
            {
                Id = x.Id,
                TitleFa = x.TitleFa ?? "", 
                TitleAr = x.TitleAr ?? "",
                TitleRu = x.TitleRu ?? "",
                TitleEn = x.TitleEn ?? "",
                LinkAr = x.LinkAr ?? "",
                LinkEn = x.LinkEn ?? "",
                LinkFa = x.LinkFa ?? "",
                LinkRu = x.LinkRu ?? "",
                PosterStr = x.Poster ?? ""
            }).ToList();
    
        }
    }
}