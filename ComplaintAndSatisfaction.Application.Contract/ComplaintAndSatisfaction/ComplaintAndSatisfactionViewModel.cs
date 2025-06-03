using System;

namespace ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction
{
    public class ComplaintAndSatisfactionViewModel
    {
        public long Id { get; set; }
        
        public string FullName { get; set; }

        public string Title { get; set; }

        public string Mobile { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public long ProductId { get; set; }
        public string ProductName { get; set; }

        public long SatisfactionLevel { get; set; }
        public string SatisfactionName { get; set; }

        public long ParentId { get; set; }
        public string ParentName { get; set; }

        public string Message { get; set; }
        public string Report { get; set; }

        public bool Answer { get; set; }

        public DateTime  DateTime { get; set; }
    }
}