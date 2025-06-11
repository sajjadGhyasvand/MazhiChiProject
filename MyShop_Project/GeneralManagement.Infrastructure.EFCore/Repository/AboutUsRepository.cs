using System.Collections.Generic;
using System.Linq;
using GeneralManagement.Application.Contracts.AboutUs;
using GeneralManagement.Application.Contracts.GeneralSetting;
using GeneralManagement.Domain.AboutAgg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Infrastructure;

namespace GeneralManagement.Infrastructure.EFCore.Repository
{
    public class AboutUsRepository:RepositoryBase<long,AboutUs>,IAboutUsRepository
    {
        private  readonly  GeneralContext _context;
        public AboutUsRepository(GeneralContext context) : base(context)
        {
            _context = context;
        }

        public EditAboutUs GetDetails(long id)
        {
            return _context.AboutUs.Select(x => new EditAboutUs()
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                Description = x.Description,
                History = x.History,
                Title =x.Title,
                ShortDescription = x.ShortDescription,
                VideosString = x.Video,
                PosterString = x.Poster
            }).FirstOrDefault(x=>x.Id ==id);
        }


        public AboutUsViewModel GetAboutId()
        {
            var aboutUs = _context.AboutUs.FirstOrDefault();

            if (aboutUs != null)
                return new AboutUsViewModel()
                {
                    Id = aboutUs.Id,
                    LanguageId = aboutUs.LanguageId,
                    History = aboutUs.History,
                    Title = aboutUs.Title,
                    Description = aboutUs.Description,
                };
            return null;
        }

        public List<AboutUsViewModel> Search(AboutUsSearchModel model)
        {
            var query = _context.AboutUs.Select(x => new AboutUsViewModel()
            {
                LanguageId = x.LanguageId,
                Description = x.Description,
                History = x.History,
                Id = x.Id,
                Title = x.Title,
                StringPoster = x.Poster,
                StringVideo = x.Video
            });
            if (model.LanguageId>0)
                query = query.Where(x => x.LanguageId == model.LanguageId);
            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}