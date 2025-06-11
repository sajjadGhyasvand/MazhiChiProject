using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.Slide;
using ShopManagement.Infrastructure.EFCore;
using System.Globalization;

namespace My_ShopQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;
        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlidesList()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            
            return _shopContext.Slides.Select(x => new SlideQueryModel
            {
                Heading = x.Heading,
                Link = x.Link,
                Text = x.Text,
                BtnText = x.BtnText,
                LanguageId = x.LanguageId,
                IsRemoved = x.IsRemoved,
            }).AsNoTracking().Where(x =>  x.IsRemoved ==false ).ToList();
        }
    }
}