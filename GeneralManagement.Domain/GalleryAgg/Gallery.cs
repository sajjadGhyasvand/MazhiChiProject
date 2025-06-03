using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.GalleryAgg
{
    public class Gallery : EntityBase
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long LanguageId { get; private set; }

        public Gallery(string title, string description, string picture, string pictureAlt, string pictureTitle,
            long languageId, string slug)
        {
            Title = title;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            LanguageId = languageId;
            Slug = slug;
        }

        public void Edit(string title, string description, string picture, string pictureAlt, string pictureTitle,
            long languageId, string slug)
        {
            Title = title;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            LanguageId = languageId;
            Slug = slug;
        }
    }
}