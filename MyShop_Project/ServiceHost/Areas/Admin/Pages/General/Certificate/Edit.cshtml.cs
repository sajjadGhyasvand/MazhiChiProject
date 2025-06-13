using GeneralManagement.Application.Contracts.Certificate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Certificate
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
 
        public EditCertificate Command;
        public SelectList ListLanguage;
        private readonly ICertificateApplication _certificateApplication;
        public EditModel(ICertificateApplication certificateApplication)
        {
            _certificateApplication = certificateApplication;
        }


        public void OnGet(long id)
        {
            Command = _certificateApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditCertificate command)
        {
            if (ModelState.IsValid)
            {
                var result = _certificateApplication.Edit(command);
                if (result.IsSuccess)
                {
                    return RedirectToPage("./Index");
                }
                Message = result.Massage;
                Command = command;
                return Page();
            }
            Command = command;
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
