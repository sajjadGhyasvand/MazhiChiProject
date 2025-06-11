using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace BlogManagement.Application.Contracts.Articles
{
    public interface IArticlesApplication
    {
        OperationResult Create(CreateArticles command);
        OperationResult Edit(EditArticles command);
        EditArticles GetDetails(long id);
        List<ArticlesViewModel> Search(ArticlesSearchModel searchModel);
        List<ArticlesViewModel> GetArticles();
        ArticlesViewModel GetArticle(long id);
    }
}