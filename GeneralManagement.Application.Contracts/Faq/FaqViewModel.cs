namespace GeneralManagement.Application.Contracts.Faq
{
    public class FaqViewModel
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public long LanguageId { get; set; }
        public bool IsRemoved { get; set; }

    }
}