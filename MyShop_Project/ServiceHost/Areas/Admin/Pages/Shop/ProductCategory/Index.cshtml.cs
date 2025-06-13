using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCategoryViewModels;
        public ProductCategorySearchModel SearchModel;
        public SelectList ListLanguage;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategoryViewModels = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductCategory
            {
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductCategory commend)
        {
            OperationResult result =new OperationResult();
            if (ModelState.IsValid)
            {
                result = _productCategoryApplication.Create(commend);
                return new JsonResult(result);
            } 
            Partial("./Create", commend);
            return new JsonResult(result.NotValid());
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _productCategoryApplication.GetDetails(id);

            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditProductCategory commend)
        {
            OperationResult result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _productCategoryApplication.Edit(commend);
                return new JsonResult(result);
            }
            Partial("./Create", commend);
            return new JsonResult(result.NotValid());
           
        }
    }
}