using GeneralManagement.Application.Contracts.AboutUs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.AboutUs
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateAboutUs Command;
        public SelectList ListLanguage;
        private readonly IAboutUsApplication _aboutUsApplication;

        public CreateModel(IAboutUsApplication aboutUsApplication)
        {
            _aboutUsApplication = aboutUsApplication;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateAboutUs command)
        {
            var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _aboutUsApplication.Create(command);
                return RedirectToPage("./Index");
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
