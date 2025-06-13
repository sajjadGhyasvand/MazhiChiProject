
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Admin.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<SlideViewModel> SlideViewModels;
        public SliderSearchModel SearchModel;
        public SelectList ListLanguage;
        private readonly ISlideApplication _slideApplication;
        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet(SliderSearchModel searchModel)
        {
            SlideViewModels = _slideApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide()
            {
               
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateSlide commend)
        {
            OperationResult result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _slideApplication.Create(commend);
                return new JsonResult(result);
            }
            Partial("./Create", commend);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetDetails(id);
            return Partial("./Edit", slide);
        }
        public JsonResult OnPostEdit(EditSlide commend)
        {
            OperationResult result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _slideApplication.Edit(commend);
                return new JsonResult(result);
            }
            Partial("./Edit", commend);
            return new JsonResult(result.NotValid());
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _slideApplication.Remove(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return RedirectToPage("./Index");
        }
        public IActionResult OnRestore(long id)
        {
            var result = _slideApplication.Restore(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return RedirectToPage("./Index");
        }
    }
}
