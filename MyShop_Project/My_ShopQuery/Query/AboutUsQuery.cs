using GeneralManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.AboutUs;
using System.Globalization;

namespace My_ShopQuery.Query
{
    public class AboutUsQuery:IAboutUsQueryModel
    {
        private readonly GeneralContext _generalContext;


        public AboutUsQuery(GeneralContext generalContext)
        {


            _generalContext = generalContext;
        }


        public  AboutUsQueryModel AboutUs()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            return _generalContext.AboutUs.Select(a => new AboutUsQueryModel
                {
                    Title = a.Title,
                    Description = a.Description,
                    ShortDescription = a.ShortDescription,
                    History = a.History,
                    Id = a.Id,
                    LanguageId = a.LanguageId,
                    Poster = a.Poster,
                    Video = a.Video
                }).AsNoTracking().FirstOrDefault();
        }
    }
}