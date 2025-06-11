using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Articles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateArticles Command =new CreateArticles();
        public SelectList ArticleCategories;
        public SelectList ListLanguage;
        private readonly IArticlesApplication _articlesApplication;
        private readonly IArticlesCategoryApplication _articlesCategoryApplication;
       

        public CreateModel(IArticlesApplication articlesApplication, IArticlesCategoryApplication articlesCategoryApplication)
        {
            _articlesApplication = articlesApplication;
            _articlesCategoryApplication = articlesCategoryApplication;
           
        }

        public void OnGet()
        {
            ListLanguage = new SelectList( "Id", "LanguageTitle");
            ArticleCategories = new SelectList(_articlesCategoryApplication.GetArticlesCategory(), "Id", "Name");
        }

        public IActionResult OnPost(CreateArticles command)
        {
            var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _articlesApplication.Create(command);
                return RedirectToPage("./Index");
            }
            ListLanguage = new SelectList( "Id", "LanguageTitle");
            ArticleCategories = new SelectList(_articlesCategoryApplication.GetArticlesCategory(), "Id", "Name");
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
