using GeneralManagement.Application.Contracts.Faq;
using LanguageManagement.Application.Contracts.Language;
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
        private readonly ILanguageApplication _languageApplication;

        public CreateModel(IFaqApplication faqApplication, ILanguageApplication languageApplication)
        {
            _faqApplication = faqApplication;
            _languageApplication = languageApplication;
        }

        public void OnGet()
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
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
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}