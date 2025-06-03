using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;

// ReSharper disable once CheckNamespace
namespace ServiceHost.Areas.Admin.Pages.Blog.ArticlesCategory
{
    public class IndexModel : PageModel
    {
        public List<ArticlesCategoryViewModel> ArticulateCategoryViewModels;
        public ArticleCategorySearchModel SearchModel;
        public SelectList ListLanguage;
        private readonly IArticlesCategoryApplication _articulateCategoryApplication;
        private readonly ILanguageApplication _languageApplication;

        public IndexModel(IArticlesCategoryApplication articulateCategoryApplication, ILanguageApplication languageApplication)
        {
            _articulateCategoryApplication = articulateCategoryApplication;
            _languageApplication = languageApplication;
        }


        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            ArticulateCategoryViewModels = _articulateCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()

        {
            var command = new CreateArticlesCategory
            {
                ListLanguage = _languageApplication.List()
            };
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
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            return new JsonResult(result.NotValid());

           
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _articulateCategoryApplication.GetDetails(id);
            productCategory.ListLanguage = _languageApplication.List();
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
            ListLanguage = new SelectList(_languageApplication.List(), "Id", "LanguageTitle");
            return new JsonResult(result.NotValid());
        }
    }
}
