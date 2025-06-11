using My_Shop_Framework.Domain;

namespace BlogManagement.Domain.ArticlePicture.Agg
{
    public class ArticlePicture : EntityBase
    {
        public long ArticleId { get; private set; }
        public string Picture{ get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Link { get; private set; }
        public bool IsRemoved { get; private set; }
        public BlogManagement.Domain.Articles.Agg.Articles Article { get; private set; }

        public ArticlePicture(long articleId, string picture, string pictureAlt, string pictureTitle,string link)
        {
            ArticleId = articleId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Link = link;
            IsRemoved = false;
        }


        public void Edit(long articleId, string pictureName, string pictureAlt, string pictureTitle, string link)
        {
            ArticleId = articleId;
            if(!string.IsNullOrWhiteSpace(pictureName))
                Picture = pictureName;
            PictureAlt = pictureAlt;
            Link = link;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}