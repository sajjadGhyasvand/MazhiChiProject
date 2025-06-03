using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticlePicture;
using BlogManagement.Application.Contracts.Articles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Blog.Articles
{
    public class ArticleGalleryModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<ArticlePictureViewModel> ArticlePictures;
        public ArticlePictureSearchModel SearchModel;
        public ArticlesViewModel Article;

        private readonly IArticlesApplication _articlesApplication;
        private readonly IArticlePictureApplication _articlePictureApplication;

        public ArticleGalleryModel(IArticlesApplication articlesApplication, IArticlePictureApplication articlePictureApplication)
        {
            _articlesApplication = articlesApplication;
            _articlePictureApplication = articlePictureApplication;
        }


        public void OnGet(long id)
        {
            Article = _articlesApplication.GetArticle(id);
            ArticlePictures = _articlePictureApplication.ListBy(id);
        }

        public IActionResult OnGetCreatePicture(long id)
        {
            var command = new CreateArticlePicture
            {
                ArticleId = id
                ,ArticleTitle = _articlesApplication.GetArticle(id).Title
            };
            return Partial("./CreatePicture", command);
        }

        public JsonResult OnPostCreatePicture(CreateArticlePicture commend)
        {
            var result = _articlePictureApplication.Create(commend);
            return new JsonResult(result);
        }

        public IActionResult OnGetEditPicture(long id)
        {
            var articlePicture = _articlePictureApplication.GetDetails(id);
            articlePicture.ArticleTitle = _articlesApplication.GetArticle(id).Title;
            return Partial("./EditPicture", articlePicture);
        }
        public JsonResult OnPostEditPicture(EditArticlePicture commend)
        {
            var result = _articlePictureApplication.Edit(commend);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _articlePictureApplication.IsRemove(id);
            var article = _articlePictureApplication.GetBy(id);
            if (result.IsSuccess)
                return RedirectToPage("./ArticleGallery", new { id = article.ArticleId });
            Message = result.Massage;
            return RedirectToPage("./ArticleGallery", new { id = article.ArticleId });
        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _articlePictureApplication.Restore(id);
            var article = _articlePictureApplication.GetBy(id);
            if (result.IsSuccess)
                return RedirectToPage("./ArticleGallery",new {id= article.ArticleId});
            Message = result.Massage;
            return RedirectToPage("./ArticleGallery", new { id = article.ArticleId });
        }
    }
}
