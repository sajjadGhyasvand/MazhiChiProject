using My_Shop_Framework.Domain;
using System.Collections.Generic;
using ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction;

namespace ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg
{
    public interface IComplaintAndSatisfactionRepository :  IRepository<long, ComplaintAndSatisfaction>
    {
        List<ComplaintAndSatisfactionViewModel> SearchComplaint(SearchComplaintAndSatisfaction commend);
        List<ComplaintAndSatisfactionViewModel> SearchSatisfaction(SearchComplaintAndSatisfaction commend);
        EditComplaintAndSatisfaction GetDetails(long id);
        ComplaintAndSatisfactionViewModel GetBy(long id);
    }
}