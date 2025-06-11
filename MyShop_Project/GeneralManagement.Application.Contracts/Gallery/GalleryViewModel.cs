using System;

namespace GeneralManagement.Application.Contracts.Gallery
{
    public class GalleryViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public long LanguageId { get; set; }
        public DateTime DateTime  { get; set; }
    }
}