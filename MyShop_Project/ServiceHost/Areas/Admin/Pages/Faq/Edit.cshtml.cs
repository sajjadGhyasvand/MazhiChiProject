using GeneralManagement.Application.Contracts.Faq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.Faq
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public EditFaq Command;
        public SelectList ListLanguage;
        private readonly IFaqApplication _faqApplication;

        public EditModel(IFaqApplication faqApplication)
        {
            _faqApplication = faqApplication;

        }


        public void OnGet(long id)
        {
            Command = _faqApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditFaq command)
        {
            if (ModelState.IsValid)
            {
               var result= _faqApplication.Edit(command);
               if(result.IsSuccess)
                return RedirectToPage("./Index");
               return Page();
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
