using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction
{
    public interface IComplaintAndSatisfactionApplication
    {
        OperationResult Create(CreateComplaintAndSatisfaction commend);
        OperationResult Answer(EditComplaintAndSatisfaction comment);
        EditComplaintAndSatisfaction GetDetails(long id);
        List<ComplaintAndSatisfactionViewModel> SearchComplaint(SearchComplaintAndSatisfaction commend);
        List<ComplaintAndSatisfactionViewModel> SearchSatisfaction(SearchComplaintAndSatisfaction commend);
        ComplaintAndSatisfactionViewModel GetBy(long id);
    }
}