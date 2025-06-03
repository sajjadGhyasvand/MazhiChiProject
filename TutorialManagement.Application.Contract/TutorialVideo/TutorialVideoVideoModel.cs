namespace TutorialManagement.Application.Contract.TutorialVideo
{
    public class TutorialVideoVideoModel
    {
        public long Id { get; set; }
        public string TitleFa { get;  set; }
        public string TitleEn { get;  set; }
        public string TitleAr { get;  set; }
        public string TitleRu { get;  set; }
        public string LinkFa { get; set; }
        public string LinkEn { get; set; }
        public string LinkAr { get; set; }
        public string LinkRu { get; set; }
        public string PosterStr { get; set; }
    }
}