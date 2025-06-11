using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Articles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.Blog.Articles
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public SelectList ArticleCategories;
        public EditArticles Command;
        public SelectList ListLanguage;
        private readonly IArticlesApplication _articlesApplication;
        private readonly IArticlesCategoryApplication _articlesCategoryApplication;

        public EditModel(IArticlesApplication articlesApplication, IArticlesCategoryApplication articlesCategoryApplication)
        {
            _articlesApplication = articlesApplication;
            _articlesCategoryApplication = articlesCategoryApplication;
        }


        public void OnGet(long id)
        {
            ArticleCategories = new SelectList(_articlesCategoryApplication.GetArticlesCategory(), "Id", "Name");
            Command = _articlesApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditArticles command)
        {
            var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _articlesApplication.Edit(command);
                return RedirectToPage("./Index");
            }
            ArticleCategories = new SelectList(_articlesCategoryApplication.GetArticlesCategory(), "Id", "Name");
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
