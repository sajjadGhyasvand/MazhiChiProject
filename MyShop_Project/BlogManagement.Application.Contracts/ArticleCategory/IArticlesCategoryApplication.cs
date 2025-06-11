using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticlesCategoryApplication
    {
        OperationResult Create(CreateArticlesCategory command);
        OperationResult Edit(EditArticlesCategory command);
        EditArticlesCategory GetDetails(long id);
        List<ArticlesCategoryViewModel> GetArticlesCategory();
        List<ArticlesCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}