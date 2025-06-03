using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EventManagement.Application.Contracts.Events;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace EventManagement.Application.Contracts.EventsPicture
{
    public class CreateEventsPicture
    {

        [Range(1,1000000,ErrorMessage = ValidationMessages.IsRequired)]
        public long EventId { get;set; }
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtensionLimited(new string[] { ".jpeg", ".png", ".jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormatImage)]
        public IFormFile Picture { get;set; }
        public string PictureString { get;set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string PictureAlt { get;set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر 500 می باشد")]
        public string PictureTitle { get;set; }

        public List<EventViewModel> Events { get; set; }
    }
}