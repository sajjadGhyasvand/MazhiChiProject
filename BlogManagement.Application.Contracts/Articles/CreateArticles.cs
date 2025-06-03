using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace BlogManagement.Application.Contracts.Articles
{
    public class CreateArticles
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string Title { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(550, ErrorMessage = "تعداد کاراکتر 550 مجاز می باشد")]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = "تعداد کاراکتر   80 مجاز می باشد")]
        public string Keywords { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".webp", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Picture { get; set; }
        public string PictureString { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 مجاز می باشد")]
        public string PictureTitle { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر 150 مجاز می باشد")]
        public string MetDescription { get; set; }

        public string CanonicalAddress { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکتر 1000 مجاز می باشد")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get; set; }

        public string PublishDate { get; set; }

        public bool CommentActive { get; set; }
        public List<ArticlesViewModel> ArticlesViewModels { get; set; }
        public List<LanguageViewModel> ListLanguage { get; set; }
    }
}
