using GeneralManagement.Application.Contracts.GeneralSetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Shop_Framework.Application;

namespace ServiceHost.Areas.Admin.Pages.General.GeneralSetting
{
    public class EditModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public EditGeneralSetting Command;
        public SelectList ListLanguage;
        private readonly IGeneralSettingApplication _generalSettingApplication;

        public EditModel( IGeneralSettingApplication generalSettingApplication1)
        {
            _generalSettingApplication = generalSettingApplication1;
        }


        public void OnGet(long id)
        {
            Command = _generalSettingApplication.GetDetails(id);
        }
        public IActionResult OnPost(EditGeneralSetting command)
        { var result = new OperationResult();
            if (ModelState.IsValid)
            {
                result = _generalSettingApplication.Edit(command);
                return RedirectToPage("./Index");
            }
            Message = ValidationMessages.ReturnPageFail;
            return Page();
        }
    }
}
