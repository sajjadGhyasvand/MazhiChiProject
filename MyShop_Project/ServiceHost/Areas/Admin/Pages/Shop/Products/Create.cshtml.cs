using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;

namespace ServiceHost.Areas.Admin.Pages.Shop.Products
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public CreateProduct Command;
        public SelectList ProductCategories;
        public SelectList ListLanguage;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
       }

        public IActionResult OnPost(CreateProduct command)
        {
            command.ShopType = ShopType.Product;
            if (ModelState.IsValid)
            {
                var result= _productApplication.Create(command);


                if (result.IsSuccess)
                {
                    return RedirectToPage("./Index");
                }
                Message = result.Massage;
                ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
                return Page();
            }
            Message = ValidationMessages.ReturnPageFail;
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            return Page();
        }
    }
}