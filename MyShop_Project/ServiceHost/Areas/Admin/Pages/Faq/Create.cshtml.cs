using GeneralManagement.Application.Contracts.Faq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.Faq
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateFaq Command;
        public SelectList ListLanguage;
        private readonly IFaqApplication _faqApplication;

        public CreateModel(IFaqApplication faqApplication)
        {
            _faqApplication = faqApplication;
        }

        public void OnGet()
        {
         
        }

        public IActionResult OnPost(CreateFaq command)
        {
            if (ModelState.IsValid)
            {
                var result = _faqApplication.Create(command);
                if (result.IsSuccess)
                    return RedirectToPage("./Index");
                return Page();
            }
            
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}