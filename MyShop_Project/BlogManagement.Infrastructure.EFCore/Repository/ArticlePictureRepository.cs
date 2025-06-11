using My_Shop_Framework.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using BlogManagement.Application.Contracts.ArticlePicture;
using BlogManagement.Domain.ArticlePicture.Agg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticlePictureRepository : RepositoryBase<long, ArticlePicture>, IArticlePictureRepository
    {
        private readonly BlogContext _context;

        public ArticlePictureRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public EditArticlePicture GetDetails(long id)
        {
            return _context.ArticlePictures.Select(x => new EditArticlePicture
            {
                Id = x.Id,
                PictureString = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ArticleId = x.ArticleId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticlePictureViewModel> Search(ArticlePictureSearchModel searchModel)
        {
            var query = _context.ArticlePictures.Include(x => x.Article).Select(x => new ArticlePictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Article = x.Article.Title,
                ArticleId = x.ArticleId,
                IsRemoved = x.IsRemoved, Link = x.Link,
            });
            query = query.Where(x => x.ArticleId == searchModel.ArticleId);
           

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<ArticlePictureViewModel> ListBy(long id)
        {
            return _context.ArticlePictures.Include(x => x.Article).Select(x => new ArticlePictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Article = x.Article.Title,
                ArticleId = x.ArticleId,
                IsRemoved = x.IsRemoved,
                PictureTitle = x.PictureTitle,
                Link = x.Link,
            }).Where(x => x.ArticleId == id).ToList();
        }

        public ArticlePictureViewModel GetBy(long id)
        {
            return _context.ArticlePictures.Include(x => x.Article).Select(x => new ArticlePictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Article = x.Article.Title,
                ArticleId = x.ArticleId,
                IsRemoved = x.IsRemoved,
                PictureTitle = x.PictureTitle,
                Link = x.Link
            }).SingleOrDefault(x => x.Id == id);
        }
    }
}