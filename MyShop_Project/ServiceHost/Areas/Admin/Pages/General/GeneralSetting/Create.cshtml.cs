using GeneralManagement.Application.Contracts.GeneralSetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.GeneralSetting
{
    public class CreateModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public CreateGeneralSetting Command;
        public SelectList ListLanguage;
        private readonly IGeneralSettingApplication _generalSettingApplication;

        public CreateModel(IGeneralSettingApplication generalSettingApplication)
        {
            _generalSettingApplication = generalSettingApplication;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateGeneralSetting command)
        {
            var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _generalSettingApplication.Create(command);
                return RedirectToPage("./Index");
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();

        }
    }
}
