namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class ArticlesCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Description { get; set; }
        public int ShowOrder { get; set; }
        public string CreateDate { get; set; }
        public long ArticulateCount { get; set; }
        public long LanguageId { get; set; }
    }
}