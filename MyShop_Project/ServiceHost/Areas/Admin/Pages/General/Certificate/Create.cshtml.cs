using GeneralManagement.Application.Contracts.Certificate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Certificate
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateCertificate Command =new CreateCertificate();
        public SelectList ListLanguage;
        private readonly ICertificateApplication _certificateApplication;
        public CreateModel(ICertificateApplication certificateApplication)
        {
            _certificateApplication = certificateApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateCertificate command)
        {
            if (ModelState.IsValid)
            {
                var result = _certificateApplication.Create(command);
                if (result.IsSuccess)
                {
                    return RedirectToPage("./Index");
                }
                Message = result.Massage;
                return Page();
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
