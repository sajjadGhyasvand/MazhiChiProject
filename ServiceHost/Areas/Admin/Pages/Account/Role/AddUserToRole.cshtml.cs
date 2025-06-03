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
    public class AddUserToRole : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public AddUserToRole(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [BindProperty(SupportsGet = true)]
        public string RoleId { get; set; }

        public string RoleName { get; set; }
        public List<UserViewModel> Users { get; set; }

        [BindProperty]
        public string SelectedUserId { get; set; }

        public async Task<IActionResult> OnGetAsync(string roleId)
        {
            RoleId = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null) return NotFound();

            RoleName = role.PersianRoleName;
            Users = _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                FullName = $"{u.FirstName} {u.LastName}"
            }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAssignUserAsync()
        {
            if (!ModelState.IsValid) return Page();

            var role = await _roleManager.FindByIdAsync(RoleId);
            var user = await _userManager.FindByIdAsync(SelectedUserId);

            if (role == null || user == null) return NotFound();

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return Page();
            }

            TempData["Success"] = $"ò«—»— '{user.UserName}' »Â ‰ﬁ‘ '{role.PersianRoleName}' «÷«›Â ‘œ.";
            return RedirectToPage("Index"); // Redirects back to Role List
        }

        public class UserViewModel
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
        }
    }
}