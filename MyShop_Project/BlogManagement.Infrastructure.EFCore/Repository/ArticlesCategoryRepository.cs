using System.Collections.Generic;
using System.Linq;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticlesCategory.Agg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticlesCategoryRepository : RepositoryBase<long, ArticlesCategory>, IArticlesCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticlesCategoryRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditArticlesCategory GetDetails(long id)
        {
            return _blogContext.ArticulateCategories.Select(x => new EditArticlesCategory
                {
                    Id = x.Id,
                    Slug = x.Slug,
                    CanonicalAddress = x.CanonicalAddress,
                    PictureAlt = x.PictureAlt,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    Name = x.Name,
                    PictureString = x.Picture,
                    PictureTitle = x.PictureTitle,
                    ShowOrder = x.ShowOrder,
                    Keywords = x.Keywords,
                    LanguageId = x.LanguageId
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<ArticlesCategoryViewModel> Search(ArticleCategorySearchModel model)
        {
            var query = _blogContext.ArticulateCategories
                .Include(x => x.Articles)
                .Select(x =>
                    new ArticlesCategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Picture = x.Picture,
                        PictureTitle = x.PictureTitle,
                        ShowOrder = x.ShowOrder,
                        Description = x.Description,
                        PictureAlt = x.PictureAlt,
                        CreateDate = x.CreationDateTime.ToFarsi(),
                        ArticulateCount = x.Articles.Count,
                        LanguageId = x.LanguageId,
                    }
                );

            if (!string.IsNullOrWhiteSpace(model.Name))
                query = query.Where(x => x.Name.Contains(model.Name));
            if (model.LanguageId > 0)
                query = query.Where(x => x.Id == model.LanguageId);
            return query.OrderByDescending(x => x.ShowOrder).ToList();
        }

        public List<ArticlesCategoryViewModel> GetArticlesCategory()
        {
            return _blogContext.ArticulateCategories.Select(x => new ArticlesCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public string GetSlugBy(long id)
        {
            return _blogContext.ArticulateCategories.SingleOrDefault(x => x.Id == id)?.Slug;
        }
    }
}