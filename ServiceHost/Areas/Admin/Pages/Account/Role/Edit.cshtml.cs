using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using My_Shop_Framework.Infrastructure;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ServiceHost.Areas.Admin.Pages.Account.Role
{
    public class EditModel : PageModel
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        [BindProperty]
        public EditRole Command { get; set; }

        public EditModel(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            Command = new EditRole
            {
                Id = role.Id,
                Name = role.Name,
                PersianName = role.PersianRoleName
            };
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var role = await _roleManager.FindByIdAsync(Command.Id);
            if (role == null) return NotFound();

            role.Name = Command.Name;
            role.PersianRoleName = Command.PersianName;

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
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

