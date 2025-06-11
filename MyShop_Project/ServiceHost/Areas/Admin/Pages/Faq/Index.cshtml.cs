using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Faq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Faq
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public List<FaqViewModel> FaqViewModels;
        private readonly IFaqApplication _faqApplication;

        public IndexModel(IFaqApplication faqApplication)
        {
            _faqApplication = faqApplication;
           
        }
        public void OnGet()
        {
            FaqViewModels = _faqApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
           
            return Partial("./Create");
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _faqApplication.IsRemove(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return Page();
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _faqApplication.Restore(id); 
            if (result.IsSuccess)
                return RedirectToPage("./Index");
            Message = result.Massage;
            return Page();
        }
    }
}