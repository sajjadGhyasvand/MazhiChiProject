namespace BlogManagement.Application.Contracts.Articles
{
    public class ArticlesSearchModel
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public long LanguageId { get; set; }
    }
}