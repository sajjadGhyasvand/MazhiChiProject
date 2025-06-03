using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace TutorialManagement.Application.Contract.IntroductionVideo
{
    public class CreateIntroductionVideo
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(2000, ErrorMessage = "تعداد کاراکتر 2000 می باشد")]
        public string Link { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Poster { get; set; }
        public string PosterStr { get; set; }

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get; set; }
    }
}