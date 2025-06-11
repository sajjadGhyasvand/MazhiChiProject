using GeneralManagement.Domain.CertificateAgg;
using My_Shop_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralManagement.Application.Contracts.Certificate;
using GeneralManagement.Application.Contracts.Faq;
using GeneralManagement.Domain.FaqAgg;
using Microsoft.EntityFrameworkCore;
using GeneralManagement.Application.Contracts.AboutUs;

namespace GeneralManagement.Infrastructure.EFCore.Repository
{
    public class FaqRepository : RepositoryBase<long, Faq>, IFaqRepository
    {
        private readonly GeneralContext _generalContext;
        public FaqRepository(GeneralContext generalContext) : base(generalContext)
        {
            _generalContext = generalContext;
        }


        public EditFaq GetDetails(long id)
        {
            return _generalContext.Faqs.Select(x => new EditFaq()
            {
                Id = x.Id,
                LanguageId = x.LanguageId,
               Answer = x.Answer,
               Question = x.Question,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<FaqViewModel> GetList()
        {
            return _generalContext.Faqs.Select(x => new FaqViewModel()
            {
                Question = x.Question,
                LanguageId = x.LanguageId,
                Answer = x.Answer,
                IsRemoved = x.IsRemoved,
                Id = x.Id
            }).ToList();
        }
    }
}
