using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.AboutUs
{
    public class CreateAboutUs
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string Title { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(5000 , ErrorMessage = "تعداد کاراکتر 5000 مجاز می باشد")]
        public string ShortDescription { get; set; }

        public string History { get;  set; }

        [Range(0,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get;  set; }

        public IFormFile Videos { get; set; }
        public string VideosString { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".webp", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Poster { get; set; }
        public string PosterString { get; set; }

    }
}
