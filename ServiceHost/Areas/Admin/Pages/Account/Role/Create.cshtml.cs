using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Application.Contracts.Role;

namespace ServiceHost.Areas.Admin.Pages.Account.Role
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateRole Command { get; set; } = new CreateRole();

        public List<string> Policies { get; set; }

        private readonly RoleManager<ApplicationRole> _roleManager;
        public CreateModel(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public void OnGet()
        {
          
        }

        public async Task<IActionResult> OnPost(CreateRole command)
        {
            var role = new ApplicationRole
            {
                Name = command.Name,
                PersianRoleName = command.PersianName,
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                // Additional role policy handling here if needed
                return RedirectToPage("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
