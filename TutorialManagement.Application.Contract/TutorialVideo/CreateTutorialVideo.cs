using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace TutorialManagement.Application.Contract.TutorialVideo
{
    public class CreateTutorialVideo
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string TitleFa { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string TitleEn { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string TitleAr { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string TitleRu { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(2000, ErrorMessage = "تعداد کاراکتر 2000 می باشد")]
        public string LinkFa { get; set; }
        [MaxLength(2000, ErrorMessage = "تعداد کاراکتر 2000 می باشد")]
        public string LinkEn { get; set; }
        [MaxLength(2000, ErrorMessage = "تعداد کاراکتر 2000 می باشد")]
        public string LinkAr { get; set; }
        [MaxLength(2000, ErrorMessage = "تعداد کاراکتر 2000 می باشد")]
        public string LinkRu { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Poster { get; set; }
        public string PosterStr { get; set; }
    }
}