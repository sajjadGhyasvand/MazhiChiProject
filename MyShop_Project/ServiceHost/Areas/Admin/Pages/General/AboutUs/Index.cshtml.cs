using GeneralManagement.Application.Contracts.AboutUs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.General.AboutUs
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public AboutUsSearchModel SearchModel;
        public List<AboutUsViewModel> AboutUsViewModels;
        public SelectList ListLanguage;
        private readonly IAboutUsApplication _aboutUsApplication;

        public IndexModel(IAboutUsApplication aboutUsApplication)
        {
            _aboutUsApplication = aboutUsApplication;
        }


        public void OnGet(AboutUsSearchModel model)
        {
            AboutUsViewModels = _aboutUsApplication.Search(model);
        }
    }
}
