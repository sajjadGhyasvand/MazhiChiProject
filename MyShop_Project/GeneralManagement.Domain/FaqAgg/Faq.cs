using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.FaqAgg
{
    public class Faq : EntityBase
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public long LanguageId { get; private set; }
        public bool IsRemoved { get; set; }

        public Faq(string question, string answer, long languageId)
        {
            Question = question;
            Answer = answer;
            LanguageId = languageId;
            IsRemoved = false;
        }

        public void Edit(string question, string answer, long languageId)
        {

            Question = question;
            Answer = answer;
            LanguageId = languageId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}