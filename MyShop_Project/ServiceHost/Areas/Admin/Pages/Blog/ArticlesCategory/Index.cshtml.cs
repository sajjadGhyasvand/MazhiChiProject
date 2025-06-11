using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

// ReSharper disable once CheckNamespace
namespace ServiceHost.Areas.Admin.Pages.Blog.ArticlesCategory
{
    public class IndexModel : PageModel
    {
        public List<ArticlesCategoryViewModel> ArticulateCategoryViewModels;
        public ArticleCategorySearchModel SearchModel;
        public SelectList ListLanguage;
        private readonly IArticlesCategoryApplication _articulateCategoryApplication;

        public IndexModel(IArticlesCategoryApplication articulateCategoryApplication)
        {
            _articulateCategoryApplication = articulateCategoryApplication;
        }


        public void OnGet(ArticleCategorySearchModel searchModel)
        {
           
            ArticulateCategoryViewModels = _articulateCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()

        {
           
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateArticlesCategory commend)
        {

            OperationResult result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _articulateCategoryApplication.Create(commend);
                return new JsonResult(result);
            }
            Partial("./Create", commend);
            
            return new JsonResult(result.NotValid());

           
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _articulateCategoryApplication.GetDetails(id);
            
            return Partial("./Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditArticlesCategory commend)
        {
       
            OperationResult result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _articulateCategoryApplication.Edit(commend);
                return new JsonResult(result);
            }
            Partial("./Edit", commend);
          
            return new JsonResult(result.NotValid());
        }
    }
}
