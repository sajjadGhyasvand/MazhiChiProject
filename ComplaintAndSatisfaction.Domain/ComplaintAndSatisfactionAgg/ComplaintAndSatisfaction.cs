using My_Shop_Framework.Domain;

namespace ComplaintAndSatisfactionManagement.Domain.ComplaintAndSatisfactionAgg
{
    public class ComplaintAndSatisfaction:EntityBase
    {
        private readonly string _title;
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

        public bool IsAnswer { get; set; }

        public ComplaintAndSatisfaction(string title, string fullName, string mobile, string phoneNumber, string email, long productId,
            string productName, long satisfactionLevel, string satisfactionName, long parentId,
            string parentName, string message)
        {
            Title = title;
            FullName = fullName;
            Mobile = mobile;
            PhoneNumber = phoneNumber;
            Email = email;
            ProductId = productId;
            ProductName = productName;
            SatisfactionLevel = satisfactionLevel;
            SatisfactionName = satisfactionName;
            ParentId = parentId;
            ParentName = parentName;
            Message = message;
        }
        public void Answer()
        {
            IsAnswer = true;
        }
    }
}