using GeneralManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Faq;
using System.Globalization;

namespace My_ShopQuery.Query
{
    public class FaqQuery:IFaqQueryModel
    {
        private readonly  GeneralContext _context;
        public FaqQuery(GeneralContext context)
        {
            _context = context;
        }

        public List<FaqQueryModel> GetAll()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();

                var faq = _context.Faqs.Select(x => new FaqQueryModel()
                {
                    Question = x.Question,
                    LanguageId = x.LanguageId,
                    Answer = x.Answer,
                    Id = x.Id,
                    IsRemoved = x.IsRemoved,
                });
                faq = faq.Where(x => x.IsRemoved == false);

                return faq.ToList();

        }
    }
}