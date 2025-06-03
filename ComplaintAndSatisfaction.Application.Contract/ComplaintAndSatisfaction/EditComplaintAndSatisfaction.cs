using System.ComponentModel.DataAnnotations;
using My_Shop_Framework.Application;

namespace ComplaintAndSatisfaction.Application.Contract.ComplaintAndSatisfaction
{
    public class EditComplaintAndSatisfaction
    {
        public long Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(2000, ErrorMessage = "تعداد کاراکتر  2000 مجاز می باشد")]
        public string Report { get; set; }

        public  bool IsAnswer { get; set; }
    }
}