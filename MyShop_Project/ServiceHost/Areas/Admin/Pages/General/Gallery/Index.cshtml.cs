using GeneralManagement.Application.Contracts.Gallery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.General.Gallery
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public GallerySearchModel SearchModel;
        public List<GalleryViewModel> GalleryViewModel;
        public SelectList ListLanguage;
        private readonly IGalleryApplication _galleryApplication;


        public IndexModel(IGalleryApplication galleryApplication)
        {
            _galleryApplication = galleryApplication;
        }
        public void OnGet(GallerySearchModel searchModel)
        {
            GalleryViewModel = _galleryApplication.Search(searchModel);
        }
    }
}
