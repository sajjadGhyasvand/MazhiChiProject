using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public EditProduct Command;
        public SelectList ProductCategories;
        public SelectList ListLanguage;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(long id)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Command = _productApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditProduct command)
        {
            if (ModelState.IsValid)
            {
                var result = _productApplication.Edit(command);
                if (result.IsSuccess)
                    return RedirectToPage("./Index");
                ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
                Command = _productApplication.GetDetails(command.Id);
                Message = result.Massage;
                return Page();
            }
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Command = _productApplication.GetDetails(command.Id);
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}