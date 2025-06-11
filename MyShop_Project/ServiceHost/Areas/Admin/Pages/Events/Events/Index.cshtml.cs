using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Articles;
using EventManagement.Application.Contracts.Events;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Events.Events
{
    public class IndexModel : PageModel
    {
        public EventSearchModel SearchModel;
        public List<EventViewModel> ArticlesViewModels;
        public SelectList ListLanguage;
        private readonly IEventApplication _eventApplication;
        private readonly ILanguageApplication _languageApplication;

        public IndexModel(IEventApplication eventApplication, ILanguageApplication languageApplication)
        {
            _eventApplication = eventApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet(EventSearchModel searchModel)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            ArticlesViewModels = _eventApplication.Search(searchModel);
        }
    }
}
