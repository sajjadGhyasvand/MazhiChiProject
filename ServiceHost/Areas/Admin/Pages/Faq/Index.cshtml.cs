using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Faq;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Faq
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public List<FaqViewModel> FaqViewModels;
        public List<LanguageViewModel> ListLanguage;
        private readonly IFaqApplication _faqApplication;
        private readonly ILanguageApplication _languageApplication;

        public IndexModel(IFaqApplication faqApplication, ILanguageApplication languageApplication)
        {
            _faqApplication = faqApplication;
            _languageApplication = languageApplication;
        }
        public void OnGet()
        {
            FaqViewModels = _faqApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            ListLanguage = _languageApplication.List();
            return Partial("./Create");
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _faqApplication.IsRemove(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return Page();
        }

        public IActionResult OnGetRestore(long id)

        {
            var result = _faqApplication.Restore(id); 
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return Page();
        }
    }
}