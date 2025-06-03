using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.Product;
using My_ShopQuery.Contract.ProductCategory;


namespace ServiceHost.ViewComponents
{
    public class LatestProductViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productQueryModel;

        public LatestProductViewComponent(IProductCategoryQuery productQueryModel)
        {
            _productQueryModel = productQueryModel;
        }


        public IViewComponentResult Invoke()
        {
           var categoryQueryModels = _productQueryModel.GetProductCategories();
            return View("LatestProduct", categoryQueryModels);
        }
    }
}