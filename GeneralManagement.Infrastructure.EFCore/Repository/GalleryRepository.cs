using System.Collections.Generic;
using System.Linq;
using GeneralManagement.Application.Contracts.AboutUs;
using GeneralManagement.Application.Contracts.Gallery;
using GeneralManagement.Domain.GalleryAgg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Infrastructure;

namespace GeneralManagement.Infrastructure.EFCore.Repository
{
    public class GalleryRepository : RepositoryBase<long, Gallery>, IGalleryRepository
    {
        private readonly GeneralContext _generalContext;

        public GalleryRepository(GeneralContext generalContext) : base(generalContext)
        {
            _generalContext = generalContext;
        }

        public EditGallery GetDetails(long id)
        {
            return _generalContext.Galleries.Select(x => new EditGallery()
            {
                Id = x.Id,
                LanguageId = x.LanguageId, 
                Description = x.Description,
                PictureString = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Slug = x.Slug,


            }).FirstOrDefault(x => x.Id == id);
        }

        public List<GalleryViewModel> Search(GallerySearchModel model)
        {
            var query = _generalContext.Galleries.Select(x => new GalleryViewModel()
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                DateTime = x.CreationDateTime
            });
            if (model.LanguageId > 0)
                query = query.Where(x => x.LanguageId == model.LanguageId);

            if (!string.IsNullOrWhiteSpace(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));
            return query.ToList();
        }
    }
}