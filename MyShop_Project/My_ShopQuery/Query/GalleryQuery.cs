using GeneralManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.Galley;
using System.Globalization;

namespace My_ShopQuery.Query
{
    public class GalleryQuery:IGalleryQueryModel
    {
        private  readonly  GeneralContext _generalContext;
        public GalleryQuery(GeneralContext generalContext)
        {
            _generalContext = generalContext;
        }

        public List<GalleryQueryModel> GetAll()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();

                var gallery = _generalContext.Galleries.Select(x => new GalleryQueryModel()
                {
                    LanguageId = x.LanguageId,
                    Description = x.Description,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Title = x.Title,
                    DateTime = x.CreationDateTime
                    
                }).AsNoTracking();
              return gallery.ToList();

        }
    }
}