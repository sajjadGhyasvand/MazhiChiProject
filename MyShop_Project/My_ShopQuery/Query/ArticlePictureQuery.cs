using System.Collections.Generic;
using System.Linq;
using BlogManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Article;

namespace My_ShopQuery.Query
{
    public class ArticlePictureQuery : IArticlePictureQueryModal
    {
        private readonly BlogContext _blogContext;

        public ArticlePictureQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public List<ArticlePictureQueryModal> ListArticlesPicture(long id)
        {
            return _blogContext.ArticlePictures.Where(x => x.ArticleId == id && x.IsRemoved).Select(x =>
                new ArticlePictureQueryModal
                {
                    Id = x.Id,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    IsRemoved = x.IsRemoved,
                    ArticleId = x.ArticleId,
                    Link = x.Link
                }).ToList();
        }
    }
}