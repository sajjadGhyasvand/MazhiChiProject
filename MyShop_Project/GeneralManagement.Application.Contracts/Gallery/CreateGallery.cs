using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace GeneralManagement.Application.Contracts.Gallery
{
    public class CreateGallery
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر  400 مجاز می باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر  500 مجاز می باشد")]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(4000, ErrorMessage = "تعداد کاراکتر  4000 مجاز می باشد")]
        public string Description { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".webp", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Picture { get; set; }
        public string PictureString { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر  800 مجاز می باشد")]
        public string PictureAlt { get; set; }



        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر  800 مجاز می باشد")]
        public string PictureTitle { get; set; }

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get; set; }

       
    }
}