using GeneralManagement.Application.Contracts.Gallery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.Gallery
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public CreateGallery Command;
        public SelectList ListLanguage;
        private readonly IGalleryApplication _galleryApplication;

        public CreateModel(IGalleryApplication galleryApplication)
        {
          
            _galleryApplication = galleryApplication;
        }

        public void OnGet()
        {
       }

        public IActionResult OnPost(CreateGallery command)
        {
            if (ModelState.IsValid)
            {
                var result= _galleryApplication.Create(command);
                if (result.IsSuccess)
                {
                    return RedirectToPage("./Index");
                }
                Message = result.Massage;
                return Page();
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}