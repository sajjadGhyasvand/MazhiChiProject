using System;
using System.Collections.Generic;
using System.Linq;
using BlogManagement.Application.Contracts.Articles;
using BlogManagement.Domain.Articles.Agg;
using BlogManagement.Domain.Articles.Agg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticlesRepository : RepositoryBase<long, Articles>, IArticlesRepository
    {
        private readonly BlogContext _blogContext;
        public ArticlesRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditArticles GetDetails(long id)
        {
            return _blogContext.Articles.Select(x => new EditArticles
            {
                Slug = x.Slug,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureString = x.Picture,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                LanguageId = x.LanguageId,
                ShortDescription = x.ShortDescription.Substring(0,Math.Min(x.ShortDescription.Length,50))+"...",
                MetDescription = x.MetDescription,
                PublishDate = x.PublishDate.ToString(),
                Title = x.Title,
                CommentActive = x.CommentActive,
            }).SingleOrDefault(x => x.Id == id);
        }

        public Articles GetWithCategory(long id)
        {
            return _blogContext.Articles.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticlesViewModel> Search(ArticlesSearchModel searchModel)
        {
            var query = _blogContext.Articles.Include(x=>x.Category).Select(x => new ArticlesViewModel
            {
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDateTime.ToFarsi(),
                PublishDate = x.PublishDate.ToFarsi(),
                Title = x.Title,
                Category = x.Category.Name,
                Id = x.Id,
                CategoryId = x.Category.Id,
                Picture = x.Picture,
                LanguageId = x.LanguageId

            });
            if ((!string.IsNullOrWhiteSpace(searchModel.Title)))
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);
            if (searchModel.LanguageId > 0)
                query = query.Where(x => x.LanguageId == searchModel.LanguageId);
            return query.OrderByDescending(x => x.Id).ToList();
        }

        public ArticlesViewModel GetArticle(long id)
        {
            return _blogContext.Articles.Select(x => new ArticlesViewModel()
            {
                Id = x.Id,
                Title = x.Title,
            }).SingleOrDefault(x => x.Id == id);
        }

        public List<ArticlesViewModel> GetArticles()
        {
            return _blogContext.Articles.Select(x => new ArticlesViewModel()
            {
                Id = x.Id,
                Title = x.Title

            }).ToList();
        }
    }
}