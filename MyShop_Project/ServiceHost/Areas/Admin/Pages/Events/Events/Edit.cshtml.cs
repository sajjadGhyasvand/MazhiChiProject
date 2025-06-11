using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Articles;
using EventManagement.Application.Contracts.Events;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.Events.Events
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public EditEvents Command;
        public SelectList ListLanguage;
        private readonly IEventApplication _eventApplication;
        private readonly ILanguageApplication _languageApplication;

        public EditModel(IEventApplication eventApplication, ILanguageApplication languageApplication)
        {
            _eventApplication = eventApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet(long id)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Command = _eventApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditEvents command)
        {
            if (ModelState.IsValid)
            {
                var result = _eventApplication.Edit(command);
                if (result.IsSuccess)
                    return RedirectToPage("./Index");

                Message = result.Massage;
                return Page();
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}