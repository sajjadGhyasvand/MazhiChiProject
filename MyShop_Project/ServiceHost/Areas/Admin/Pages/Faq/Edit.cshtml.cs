using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Articles;
using GeneralManagement.Application.Contracts.Faq;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.Faq
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public EditFaq Command;
        public SelectList ListLanguage;
        private readonly IFaqApplication _faqApplication;
        private readonly ILanguageApplication _languageApplication;

        public EditModel(IFaqApplication faqApplication, ILanguageApplication languageApplication)
        {
            _faqApplication = faqApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet(long id)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Command = _faqApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditFaq command)
        {
            if (ModelState.IsValid)
            {
               var result= _faqApplication.Edit(command);
               if(result.IsSuccess)
                return RedirectToPage("./Index");
               return Page();
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
