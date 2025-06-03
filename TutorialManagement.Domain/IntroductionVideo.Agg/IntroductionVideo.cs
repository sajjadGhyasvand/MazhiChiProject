using My_Shop_Framework.Domain;

namespace TutorialManagement.Domain.IntroductionVideo.Agg
{
    public class IntroductionVideo: EntityBase
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Poster { get; set; }
        public long LanguageId { get; set; }

        public IntroductionVideo(string title, string link, string poster, long languageId)
        {
            Title = title;
            Link = link;
            Poster = poster;
            LanguageId = languageId;
        }

        public void Edit(string title, string link, string poster, long languageId)
        {
            Title = title;
            Link = link;
            if (!string.IsNullOrWhiteSpace(poster))
                Poster = poster;
            LanguageId = languageId;
        }
    }
}