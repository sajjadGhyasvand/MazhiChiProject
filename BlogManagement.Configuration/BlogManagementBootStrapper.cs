using BlogManagement.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.ArticlePicture;
using BlogManagement.Application.Contracts.Articles;
using BlogManagement.Domain.ArticlePicture.Agg;
using BlogManagement.Domain.Articles.Agg;
using BlogManagement.Domain.ArticlesCategory.Agg;
using BlogManagement.Infrastructure.EFCore;
using BlogManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.ArticleCategory;
using My_ShopQuery.Query;

namespace BlogManagement.Configuration
{
    public class BlogManagementBootStrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IArticlesCategoryRepository, ArticlesCategoryRepository>();
            service.AddTransient<IArticlesCategoryApplication, ArticlesCategoryApplication>();
            service.AddTransient<IArticlesRepository, ArticlesRepository>();
            service.AddTransient<IArticlesApplication, ArticlesApplication>();

            service.AddTransient<IArticlePictureRepository, ArticlePictureRepository>();
            service.AddTransient<IArticlePictureApplication, ArticlePictureApplication>();

            service.AddTransient<IArticleCategoryQueryModel, ArticleCategoryQuery>();
            service.AddTransient<IArticleQueryModel, ArticleQuery>();

            service.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));

        }
    }
}