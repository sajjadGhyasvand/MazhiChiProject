using System.Collections.Generic;
using GeneralManagement.Application.Contracts.AboutUs;
using GeneralManagement.Application.Contracts.Faq;
using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.FaqAgg
{
    public interface IFaqRepository : IRepository<long,Faq>
    {
        EditFaq GetDetails(long id);
        List<FaqViewModel> GetList();
    }
}