using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.ProductCategory;
using My_ShopQuery.Contract.Slide;
using My_ShopQuery.Contract.Slider;

namespace ServiceHost.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private readonly ISlideQuery _slideQuery;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public SliderViewComponent(ISlideQuery slideQuery, IProductCategoryQuery productCategoryQuery)
        {
            _slideQuery = slideQuery;
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = new SliderQueryModel()
            {
               SlideQueryModels = _slideQuery.GetSlidesList(),
            };
            return View("Slider", result);
        }
    }
}