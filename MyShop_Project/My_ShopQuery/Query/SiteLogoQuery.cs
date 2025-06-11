using System.Globalization;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;

using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.SiteLogo;

namespace My_ShopQuery.Query
{
    public class SiteLogoQuery:ISiteLogoQueryModel
    {
        private readonly GeneralContext _context;

        public SiteLogoQuery(GeneralContext context)
        {
            _context = context;
        }

        public SiteLogoQueryModel GetLogo()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var  logo =_context.SiteLogos.AsNoTracking().FirstOrDefault();

            if (logo != null)
            {
                var logoQuery = new SiteLogoQueryModel()
                {
                    Title = logo.Title,
                    Picture = logo.Picture,
                    PictureTitle = logo.PictureTitle,
                    Link = logo.Link,
                    Id = logo.Id,
                    PictureAlt = logo.PictureAlt,
                };
                return logoQuery;
            }

            return new SiteLogoQueryModel();
        }
    }
}
