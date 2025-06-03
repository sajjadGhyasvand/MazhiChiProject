using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LanguageManagement.Application.Contracts.Language;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticlesCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر 250 می باشد")]
        public string Name { get;  set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Picture { get;  set; }
        public string PictureString { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string PictureTitle { get;  set; }

        [MaxLength(3000, ErrorMessage = ValidationMessages.MaxFileSize)]
        public string Description { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string MetaDescription { get;  set; }

        [DataType(DataType.Url,ErrorMessage =ValidationMessages.Link)]
        public string CanonicalAddress { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string Slug { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر {0} می باشد")]
        public string Keywords { get;  set; }

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long LanguageId { get; set; }

        public List<ArticlesCategoryViewModel> ArticlesCategoryViewModels { get; set; }
        public List<LanguageViewModel> ListLanguage { get; set; }
        public int ShowOrder { get;  set; }
    }
}