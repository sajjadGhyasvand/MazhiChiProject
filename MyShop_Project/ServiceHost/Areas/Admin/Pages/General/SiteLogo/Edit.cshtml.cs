using GeneralManagement.Application.Contracts.SiteLogo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.SiteLogo
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public EditSiteLogo Command;
        public SelectList ListLanguage;
        private readonly ISiteLogoApplication _siteLogoApplication;

        public EditModel(ISiteLogoApplication siteLogoApplication)
        {
            _siteLogoApplication = siteLogoApplication;
        }


        public void OnGet(long id)
        {
            Command = _siteLogoApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditSiteLogo command)
        {
            if (ModelState.IsValid)
            {
                var result = _siteLogoApplication.Edit(command);
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