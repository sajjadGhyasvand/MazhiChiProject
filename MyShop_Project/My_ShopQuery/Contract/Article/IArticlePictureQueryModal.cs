using System.Collections.Generic;

namespace My_ShopQuery.Contract.Article
{
    public interface IArticlePictureQueryModal
    {
        List<ArticlePictureQueryModal> ListArticlesPicture(long id);
    }
}