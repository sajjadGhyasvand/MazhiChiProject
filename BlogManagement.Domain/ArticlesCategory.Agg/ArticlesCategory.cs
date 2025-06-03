using System.Collections.Generic;
using My_Shop_Framework.Domain;

namespace BlogManagement.Domain.ArticlesCategory.Agg
{
    public class ArticlesCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Description { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public int ShowOrder { get; private set; }
        public long LanguageId { get; private set; }
        public  List<BlogManagement.Domain.Articles.Agg.Articles> Articles { get;private set; }

        public ArticlesCategory(string name, string picture, string pictureAlt,
            string pictureTitle, string description, string metaDescription, string canonicalAddress,
            string slug, string keywords, int showOrder, long languageId)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Slug = slug;
            Keywords = keywords;
            ShowOrder = showOrder;
            LanguageId = languageId;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, 
            string description, string metaDescription, string canonicalAddress, string slug,
            string keywords, int showOrder, long languageId)
        {
            Name = name;
            Picture = picture;
            if (!string.IsNullOrWhiteSpace(picture))
                PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Slug = slug;
            Keywords = keywords;
            ShowOrder = showOrder;
            LanguageId = languageId;
        }
    }
}