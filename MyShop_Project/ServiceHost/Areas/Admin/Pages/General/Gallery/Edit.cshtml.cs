using GeneralManagement.Application.Contracts.Gallery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Gallery
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public EditGallery Command;
        public List<GalleryViewModel> GalleryViewModels;
        public SelectList ListLanguage;
        private readonly IGalleryApplication _galleryApplication;

        public EditModel(
             IGalleryApplication galleryApplication)
        {
            _galleryApplication = galleryApplication;
        }


        public void OnGet(long id)
        { 
            Command = _galleryApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditGallery command)
        {
            if (ModelState.IsValid)
            {
                var result = _galleryApplication.Edit(command);
                if (result.IsSuccess)
                    return RedirectToPage("./Index");
                Message = result.Massage;
                return Page();
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}