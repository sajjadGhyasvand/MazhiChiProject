using ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction;
using System.Collections.Generic;
using ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg;
using My_Shop_Framework.Application;

namespace ComplaintAndSatisfaction.Application
{
    public class ComplaintAndSatisfactionApplication: IComplaintAndSatisfactionApplication
    {
        private readonly IComplaintAndSatisfactionRepository _complaintAndSatisfactionRepository;

        public ComplaintAndSatisfactionApplication(IComplaintAndSatisfactionRepository complaintAndSatisfactionRepository)
        {
            _complaintAndSatisfactionRepository = complaintAndSatisfactionRepository;
        }


        public OperationResult Create(CreateComplaintAndSatisfaction commend)
        {
            var operation = new OperationResult();
            var complaintAndSatisfaction = new ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg.ComplaintAndSatisfaction(commend.Title ,commend.FullName, commend.Mobile, commend.PhoneNumber, commend.Email, commend.ProductId
                , commend.ProductName, commend.SatisfactionLevel, commend.SatisfactionName, commend.ParentId, commend.ParentName, commend.Message);
            _complaintAndSatisfactionRepository.Create(complaintAndSatisfaction);
            _complaintAndSatisfactionRepository.SaveChanges();
            return operation.Success();
        }
        public OperationResult Answer(EditComplaintAndSatisfaction comment)
        {
            var operation = new OperationResult();
            var complaintAndSatisfaction = _complaintAndSatisfactionRepository.Get(comment.Id);
            if (complaintAndSatisfaction == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            complaintAndSatisfaction.Answer();
            _complaintAndSatisfactionRepository.SaveChanges();
            return operation.Success();
        }


        public EditComplaintAndSatisfaction GetDetails(long id)
        {
            return _complaintAndSatisfactionRepository.GetDetails(id);
        }

        public List<ComplaintAndSatisfactionViewModel> SearchComplaint(SearchComplaintAndSatisfaction commend)
        {
            return _complaintAndSatisfactionRepository.SearchComplaint(commend);
        }

        public List<ComplaintAndSatisfactionViewModel> SearchSatisfaction(SearchComplaintAndSatisfaction commend)
        {
            return _complaintAndSatisfactionRepository.SearchSatisfaction(commend);
        }

        public ComplaintAndSatisfactionViewModel GetBy(long id)
        {
            return _complaintAndSatisfactionRepository.GetBy(id);
        }
    }
}