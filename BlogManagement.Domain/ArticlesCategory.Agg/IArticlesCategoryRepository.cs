using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;
using My_Shop_Framework.Domain;

namespace BlogManagement.Domain.ArticlesCategory.Agg
{
    public interface IArticlesCategoryRepository:IRepository<long, ArticlesCategory>
    {
        EditArticlesCategory GetDetails(long id);
        List<ArticlesCategoryViewModel> Search(ArticleCategorySearchModel model);
        List<ArticlesCategoryViewModel> GetArticlesCategory();
        string GetSlugBy(long id);
    }
}