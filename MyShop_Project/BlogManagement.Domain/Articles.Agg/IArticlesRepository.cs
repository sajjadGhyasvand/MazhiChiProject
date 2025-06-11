using System.Collections.Generic;
using BlogManagement.Application.Contracts.Articles;
using My_Shop_Framework.Domain;

namespace BlogManagement.Domain.Articles.Agg
{
    public interface IArticlesRepository : IRepository<long, BlogManagement.Domain.Articles.Agg.Articles>
    {
        EditArticles GetDetails(long id);
        BlogManagement.Domain.Articles.Agg.Articles GetWithCategory(long id);
        List<ArticlesViewModel> Search(ArticlesSearchModel searchModel);
        ArticlesViewModel GetArticle(long id);
        List<ArticlesViewModel> GetArticles();
    }
}