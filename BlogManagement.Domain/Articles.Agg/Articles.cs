using System;
using System.Collections.Generic;
using My_Shop_Framework.Domain;

namespace BlogManagement.Domain.Articles.Agg
{
    public class Articles : EntityBase
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string MetDescription { get; private set; }
        public string Keywords { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get; private set; }
        public long LanguageId { get; private set; }
        public bool CommentActive { get; private set; }

        public DateTime PublishDate { get; private set; }
        public ArticlesCategory.Agg.ArticlesCategory Category { get; private set; }
        public List<BlogManagement.Domain.ArticlePicture.Agg.ArticlePicture> ArticlePictures { get; private set; }
        public Articles(string title, string shortDescription, string description, string picture, 
            string pictureAlt, string pictureTitle, string slug, string metDescription, string keywords, 
            string canonicalAddress, long categoryId,DateTime publishDate, long languageId, bool commentActive)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            MetDescription = metDescription;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            PublishDate = publishDate;
            LanguageId = languageId;
            CommentActive = commentActive;
        }

        public void Edit(string title, string shortDescription,
            string description, string picture, string pictureAlt, 
            string pictureTitle, string slug, string metDescription,
            string keywords, string canonicalAddress, long categoryId, DateTime publishDate, long languageId, bool commentActive)
        {
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            MetDescription = metDescription;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            PublishDate = publishDate;
            LanguageId = languageId;
            CommentActive = commentActive;
        }
    }
}
