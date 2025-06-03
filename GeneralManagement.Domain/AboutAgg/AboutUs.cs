using System;
using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.AboutAgg
{
    public class AboutUs : EntityBase
    {
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string History { get; private set; }
        public long LanguageId { get; private set; }
        public string Video { get; private set; }
        public string Poster { get; private set; }

        public AboutUs(string title, string description, string history, long languageId, string shortDescription,
            string video, string poster)
        {
            Title = title;
            Description = description;
            History = history;
            LanguageId = languageId;
            ShortDescription = shortDescription;
            Video = video;
            Poster = poster;
        }

        public void Edit(string title, string description, string history, long languageId, string shortDescription,
            string video, string poster)
        {
            Title = title;
            Description = description;
            History = history;
            LanguageId = languageId;
            ShortDescription = shortDescription;
            if (!string.IsNullOrWhiteSpace(video))
                Video = video;
            if (!string.IsNullOrWhiteSpace(poster))
                Poster = poster;
        }
    }
}