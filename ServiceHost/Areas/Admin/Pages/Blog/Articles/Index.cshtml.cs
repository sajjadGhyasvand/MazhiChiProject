using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Articles;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {
        public ArticlesSearchModel SearchModel;
        public List<ArticlesViewModel> ArticlesViewModels;
        public SelectList ArticleCategories;
        public SelectList ListLanguage;
        private readonly IArticlesApplication _articlesApplication;
        private readonly IArticlesCategoryApplication _articlesCategoryApplication;
        private readonly ILanguageApplication _languageApplication;

        public IndexModel(IArticlesApplication articlesApplication, IArticlesCategoryApplication articlesCategoryApplication, ILanguageApplication languageApplication)
        {
            _articlesApplication = articlesApplication;
            _articlesCategoryApplication = articlesCategoryApplication;
            _languageApplication = languageApplication;
        }

        public void OnGet(ArticlesSearchModel searchModel)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            ArticleCategories = new SelectList(_articlesCategoryApplication.GetArticlesCategory(), "Id", "Name");
            ArticlesViewModels = _articlesApplication.Search(searchModel);
        }
    }
}
