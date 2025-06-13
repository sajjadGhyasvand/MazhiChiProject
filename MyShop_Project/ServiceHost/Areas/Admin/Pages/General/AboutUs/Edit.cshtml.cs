using GeneralManagement.Application.Contracts.AboutUs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.AboutUs
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
 
        public EditAboutUs Command;
        public SelectList ListLanguage;
        private readonly IAboutUsApplication _aboutUsApplication;

        public EditModel(IAboutUsApplication aboutUsApplication)
        {
            _aboutUsApplication = aboutUsApplication;
        }


        public void OnGet(long id)
        {
            Command = _aboutUsApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditAboutUs command)
        { var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _aboutUsApplication.Edit(command);
                return RedirectToPage("./Index");
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
