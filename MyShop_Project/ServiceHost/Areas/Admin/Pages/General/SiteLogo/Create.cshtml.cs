using GeneralManagement.Application.Contracts.SiteLogo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.SiteLogo
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateSiteLogo Command;
        public SelectList ListLanguage;
        private readonly ISiteLogoApplication _siteLogoApplication;

        public CreateModel(ISiteLogoApplication siteLogoApplication)
        {
            _siteLogoApplication = siteLogoApplication;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateSiteLogo command)
        {
            if (ModelState.IsValid)
            {
                var result = _siteLogoApplication.Create(command);
                if (result.IsSuccess)
                    return RedirectToPage("./Index");
                Message = result.Massage;
                return Page();
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}