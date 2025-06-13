using GeneralManagement.Application.Contracts.GeneralSetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.General.GeneralSetting
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<GeneralSettingViewModel> GeneralSettingViewModel;
        private readonly IGeneralSettingApplication _generalSettingApplication;

        public IndexModel(IGeneralSettingApplication generalSettingApplication)
        {
            _generalSettingApplication = generalSettingApplication; ;
        }

        public void OnGet()
        {
            GeneralSettingViewModel = _generalSettingApplication.GetList();
        }
    }
}