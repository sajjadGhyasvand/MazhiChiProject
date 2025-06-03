using System.Collections.Generic;

namespace ComplaintAndSatisfaction.Infrastructure.EFCore
{
    public class ComplaintAndSatisfactionType
    {
        public const long Satisfaction = 2;
        public const string SatisfactionStr = "Satisfaction";

        public const long Complaint = 1;
        public const string ComplaintStr = "Complaint";
    }

    public class ComplaintAndSatisfactionItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class ComplaintAndSatisfactionService
    {
        public List<ComplaintAndSatisfactionItem> GetComplaintAndSatisfactionList()
        {
            return new List<ComplaintAndSatisfactionItem>
            {
                new ComplaintAndSatisfactionItem { Id = ComplaintAndSatisfactionType.Satisfaction, Name = ComplaintAndSatisfactionType.SatisfactionStr },
                new ComplaintAndSatisfactionItem { Id = ComplaintAndSatisfactionType.Complaint, Name = ComplaintAndSatisfactionType.ComplaintStr }
            };

        }
    }
}