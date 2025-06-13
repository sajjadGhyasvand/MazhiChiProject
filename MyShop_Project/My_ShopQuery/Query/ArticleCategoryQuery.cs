using BlogManagement.Domain.Articles.Agg;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.ArticleCategory;
using System.Globalization;

namespace My_ShopQuery.Query
{
    public class ArticleCategoryQuery:IArticleCategoryQueryModel
    {
        private readonly BlogContext _blogContext;
        public ArticleCategoryQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;

        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            var articulateCategories = _blogContext.ArticulateCategories.Include(x=>x.Articles).Select(x=>new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                CountArticle = x.Articles.Count,

                Articles = MapArticles(x.Articles),

            }).FirstOrDefault(x=>x.Slug==slug);
            if (articulateCategories != null)
            {
                articulateCategories.KeywordList = articulateCategories.Keywords.Split("#").ToList();
              
            }
            return articulateCategories;
        }

        private static List<ArticleQueryModel> MapArticles(List<Articles> articles)
        {
            
            return articles.Select(x => new ArticleQueryModel
            {

                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).ToList();
        }

        public List<ArticleCategoryQueryModel> GetArticleCategoryQueryModels()
        {
            var currentlang = CultureInfo.CurrentCulture.ToString();

            return _blogContext.ArticulateCategories.Include(x=>x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Name = x.Name,
                Id = x.Id,
                Slug = x.Slug,
                CountArticle = x.Articles.Count,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                LanguageId=x.LanguageId,
                
            }).AsNoTracking().ToList();
        }
    }
}