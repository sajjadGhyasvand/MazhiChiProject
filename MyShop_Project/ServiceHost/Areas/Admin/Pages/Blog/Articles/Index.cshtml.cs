using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Articles;
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

        public IndexModel(IArticlesApplication articlesApplication, IArticlesCategoryApplication articlesCategoryApplication)
        {
            _articlesApplication = articlesApplication;
            _articlesCategoryApplication = articlesCategoryApplication;
        }

        public void OnGet(ArticlesSearchModel searchModel)
        {
            ArticleCategories = new SelectList(_articlesCategoryApplication.GetArticlesCategory(), "Id", "Name");
            ArticlesViewModels = _articlesApplication.Search(searchModel);
        }
    }
}
