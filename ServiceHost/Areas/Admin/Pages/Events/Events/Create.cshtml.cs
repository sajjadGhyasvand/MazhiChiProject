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
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateEvents Command =new CreateEvents();

        public SelectList ListLanguage;
        private readonly IEventApplication _eventApplication;
        private readonly ILanguageApplication _languageApplication;

        public CreateModel(ILanguageApplication languageApplication, IEventApplication eventApplication)
        {
            _languageApplication = languageApplication;
            _eventApplication = eventApplication;
        }


        public void OnGet()
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
        }

        public IActionResult OnPost(CreateEvents command)
        {
            var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _eventApplication.Create(command);
                return RedirectToPage("./Index");
            }
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
