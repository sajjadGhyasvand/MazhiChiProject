

using System.Collections.Generic;
using System.Linq;
using ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction;
using ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg;
using My_Shop_Framework.Infrastructure;

namespace ComplaintAndSatisfaction.Infrastructure.EFCore.Repository
{
    public class ComplaintAndSatisfactionRepository: RepositoryBase<long,ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg.ComplaintAndSatisfaction>,IComplaintAndSatisfactionRepository
    {
        private readonly ComplaintAndSatisfactionContext _complaintAndSatisfactionContext;

        public ComplaintAndSatisfactionRepository(ComplaintAndSatisfactionContext complaintAndSatisfactionContext):base(complaintAndSatisfactionContext)
        {
            _complaintAndSatisfactionContext = complaintAndSatisfactionContext;
        }


        public List<ComplaintAndSatisfactionViewModel> SearchComplaint(SearchComplaintAndSatisfaction commend)
        {
            var query = _complaintAndSatisfactionContext.ComplaintAndSatisfaction.Select(x => new ComplaintAndSatisfactionViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Title = x.Title,
                Message = x.Message,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ParentId = x.ParentId,
                ParentName = x.ParentName,
                PhoneNumber = x.PhoneNumber,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                SatisfactionLevel = x.SatisfactionLevel,
                SatisfactionName = x.SatisfactionName,
                Answer = x.IsAnswer,
                DateTime = x.CreationDateTime

            });
            if (!string.IsNullOrWhiteSpace(commend.Email))
                query = query.Where(x => x.Email.Contains(commend.Email));

            if (!string.IsNullOrWhiteSpace(commend.FullName))
                query = query.Where(x => x.FullName.Contains(commend.FullName));

            if (!string.IsNullOrWhiteSpace(commend.Mobile))
                query = query.Where(x => x.Mobile.Contains(commend.Mobile));

            if (!string.IsNullOrWhiteSpace(commend.PhoneNumber))
                query = query.Where(x => x.PhoneNumber.Contains(commend.PhoneNumber));

            if (commend.ProductId > 0)
                query = query.Where(x => x.ProductId == commend.ProductId);
            if (commend.Answer == 1)
                query = query.Where(x => x.Answer);

            if (commend.Answer == 2)
                query = query.Where(x => !x.Answer);
            return query.OrderByDescending(x => x.Id).Where(x => x.ParentId == ComplaintAndSatisfactionType.Complaint).ToList();
        }

        public List<ComplaintAndSatisfactionViewModel> SearchSatisfaction(SearchComplaintAndSatisfaction commend)
        {
            var query = _complaintAndSatisfactionContext.ComplaintAndSatisfaction.Select(x => new ComplaintAndSatisfactionViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Title = x.Title,
                Message = x.Message,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ParentId = x.ParentId,
                ParentName = x.ParentName,
                PhoneNumber = x.PhoneNumber,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                SatisfactionLevel = x.SatisfactionLevel,
                SatisfactionName = x.SatisfactionName,
                DateTime = x.CreationDateTime,
                Answer = x.IsAnswer,

            });
            if (!string.IsNullOrWhiteSpace(commend.Email))
                query = query.Where(x => x.Email.Contains(commend.Email));

            if (!string.IsNullOrWhiteSpace(commend.FullName))
                query = query.Where(x => x.FullName.Contains(commend.FullName));

            if (!string.IsNullOrWhiteSpace(commend.Mobile))
                query = query.Where(x => x.Mobile.Contains(commend.Mobile));

            if (!string.IsNullOrWhiteSpace(commend.PhoneNumber))
                query = query.Where(x => x.PhoneNumber.Contains(commend.PhoneNumber));

            if (commend.ProductId > 0)
                query = query.Where(x => x.ProductId == commend.ProductId);
            if (commend.Answer == 1)
                query = query.Where(x => x.Answer);

            if (commend.Answer == 2)
                query = query.Where(x => !x.Answer);
            return query.OrderByDescending(x => x.Id).Where(x => x.ParentId == ComplaintAndSatisfactionType.Satisfaction).ToList();
        }

        public EditComplaintAndSatisfaction GetDetails(long id)
        {
            return _complaintAndSatisfactionContext.ComplaintAndSatisfaction.Select(x => new EditComplaintAndSatisfaction()
            {
                Id = x.Id,
                Report = x.Report,
            }).FirstOrDefault(x => x.Id == id);

        }

        public ComplaintAndSatisfactionViewModel GetBy(long id)
        {
            return _complaintAndSatisfactionContext.ComplaintAndSatisfaction.Select(x => new ComplaintAndSatisfactionViewModel()
            {
                Id = x.Id,
                Email = x.Email,
                Answer = x.IsAnswer,
                Title = x.Title,
                ProductId = x.ProductId,
                PhoneNumber = x.PhoneNumber,
                Mobile = x.Mobile,
                FullName = x.FullName,
                Message = x.Message,
                ParentId = x.ParentId,
                ParentName = x.ParentName,
                ProductName = x.ProductName,
                SatisfactionLevel = x.SatisfactionLevel,
                SatisfactionName = x.SatisfactionName,
                DateTime = x.CreationDateTime,
                Report = x.Report
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}