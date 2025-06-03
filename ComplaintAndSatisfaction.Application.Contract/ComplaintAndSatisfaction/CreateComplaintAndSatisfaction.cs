using System;
using System.ComponentModel.DataAnnotations;
using My_Shop_Framework.Application;

namespace ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction
{
    public class CreateComplaintAndSatisfaction
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکتر  1000 مجاز می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکتر  1000 مجاز می باشد")]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(30, ErrorMessage = "تعداد کاراکتر  1000 مجاز می باشد")]
        [MobileNumber]
        public string Mobile { get; set; }

        [MaxLength(30, ErrorMessage = "تعداد کاراکتر  30 مجاز می باشد")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکتر  1000 مجاز می باشد")]
        [DataType(DataType.EmailAddress,ErrorMessage =ValidationMessages.Email)]
        public string Email { get; set; }

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        public string ProductName { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long SatisfactionLevel { get; set; }
        public string SatisfactionName { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long ParentId { get; set; }
        public string ParentName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(2000, ErrorMessage = "تعداد کاراکتر  2000 مجاز می باشد")]
        public string Message { get; set; }

    }
}