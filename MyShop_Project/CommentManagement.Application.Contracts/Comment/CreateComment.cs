using System.ComponentModel.DataAnnotations;
using My_Shop_Framework.Application;

namespace CommentManagement.Application.Contracts.Comment
{
    public class CreateComment
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر  500 مجاز می باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        [DataType(DataType.EmailAddress, ErrorMessage = ValidationMessages.PhoneNumber)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = ValidationMessages.PhoneNumber)]
        public string Phone { get; set; }
        [MaxLength(700, ErrorMessage = "تعداد کاراکتر 700 مجاز می باشد")]
        public string Subject { get;set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string Message { get; set; }

        public long OwnerId { get;  set; }
        public int Type { get;  set; }
        public long ParentId { get;  set; }
    }
}