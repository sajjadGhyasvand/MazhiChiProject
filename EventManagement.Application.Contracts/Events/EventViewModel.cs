namespace EventManagement.Application.Contracts.Events
{
    public class EventViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Slug { get; set; }
        public string Category { get; set; }
        public string CreationDate { get; set; }
        public string PublishDate { get; set; }
        public string Picture { get; set; }
        public long LanguageId { get; set; }

    }
}