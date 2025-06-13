using BlogManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_ShopQuery.Contract.Article;
using My_ShopQuery.Contract.Comment;
using ShopManagement.Infrastructure.EFCore;
using System.Globalization;

namespace My_ShopQuery.Query
{
    public class ArticleQuery : IArticleQueryModel
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext blogContext, CommentContext commentContext)
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
        }

        public List<ArticleQueryModel> LatestArticles()
        {

                var articles= _blogContext.Articles.Include(x => x.Category).Where(x => x.PublishDate <= DateTime.Now )
                    .Select(x => new ArticleQueryModel
                    {
                        Slug = x.Slug,
                        Picture = x.Picture,
                        MetDescription = x.MetDescription,
                        PictureAlt = x.PictureAlt,
                        PictureTitle = x.PictureTitle,
                        ShortDescription = x.ShortDescription,
                        CategoryName = x.Category.Name,
                        Title = x.Title
                    }).AsNoTracking().Take(3).ToList();
                return articles;
        }

        public ArticleQueryModel GetDetailsBy(string slug)
        {
            var article = _blogContext.Articles.Include(x => x.Category).Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToString(),
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.Category.Id,
                CategoryName = x.Category.Name,
                CategorySlug = x.Category.Slug,
                Description = x.Description,
                Keywords = x.Keywords,
                MetDescription = x.MetDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                CommentActive = x.CommentActive,


            }).FirstOrDefault(x => x.Slug == slug);
            var comments = _commentContext.Comments
                .Where(x => x.OwnerId == article.Id && !x.IsCancel && x.IsConfirmed && x.Type == CommentType.Article).Select(x=>new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CommentDate = x.CreationDateTime.ToFarsi(),
                    Email = x.Email,
                    Message = x.Message,
                }).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentId > 0)
                {
                    comment.ParentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
                }
            }

            if (article != null)
            {
                article.Comments = comments;
    
            }
            return article;
        }

        public List<ArticleQueryModel> Search(string value)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            long shopType = ShopType.Product;
            var query = _blogContext.Articles.Select(x => new ArticleQueryModel()
            {
                Id = x.Id,
                Slug = x.Slug,
                Title = x.Title,
                PictureTitle = x.PictureTitle,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                LangugeId = x.LanguageId,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
            }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Title.Contains(value) || x.ShortDescription.Contains(value) || x.Description.Contains(value));

            var articles = query.OrderByDescending(x => x.Id) ?? throw new ArgumentNullException("query.OrderByDescending(x => x.Id)");
            return articles.ToList();
            
        }


        public List<ArticleQueryModel> ArticlesList( int pageIndex , int pageSize)
        {
                    var skip = (pageIndex - 1) * pageSize; // محاسبه تعداد مقالاتی که باید رد شوند
                    var articles = _blogContext.Articles.Include(x => x.Category)
                        .Where(x => x.PublishDate <= DateTime.Now )
                        .OrderByDescending(x => x.PublishDate) // مرتب‌سازی بر اساس تاریخ انتشار
                        .Skip(skip) // رد کردن مقالات قبلی
                        .Take(pageSize) // فقط تعداد مشخص شده مقالات را بردارید
                        .Select(x => new ArticleQueryModel
                        {
                            Slug = x.Slug,
                            Picture = x.Picture,
                            MetDescription = x.MetDescription,
                            PictureAlt = x.PictureAlt,
                            PictureTitle = x.PictureTitle,
                            ShortDescription = x.ShortDescription,
                            CategoryName = x.Category.Name,
                            Title = x.Title
                        })
                        .AsNoTracking()
                        .ToList();

                    return articles;
        }

        public List<ArticleQueryModel> GetArticlesByCategory(string category, int pageIndex, int pageSize)
        {
            var blog= _blogContext.Articles
                .Where(x => x.Category.Slug == category) 
                .OrderByDescending(x => x.PublishDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ArticleQueryModel
                {
                    Title = x.Title,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ShortDescription = x.ShortDescription,
                    PublishDate = x.PublishDate.ToString()
                });
            return blog.ToList();
        }
    }
} 