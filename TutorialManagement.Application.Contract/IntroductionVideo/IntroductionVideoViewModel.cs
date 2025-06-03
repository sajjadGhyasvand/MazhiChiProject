namespace TutorialManagement.Application.Contract.IntroductionVideo
{
    public class IntroductionVideoViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Poster { get; set; }
        public long LanguageId { get; set; }
    }
}