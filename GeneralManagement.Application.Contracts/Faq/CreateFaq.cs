using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LanguageManagement.Application.Contracts.Language;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.Faq
{
    public class CreateFaq
    {

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر 800 مجاز می باشد")]
        public string Question { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(4000, ErrorMessage = "تعداد کاراکتر 4000 مجاز می باشد")]
        public string Answer { get; set; }

        [Range(1,long.MaxValue ,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get;  set; }

        public bool  IsRemoved { get; set; }
        public List<LanguageViewModel> LanguageList { get; set; }
 

    }
}
