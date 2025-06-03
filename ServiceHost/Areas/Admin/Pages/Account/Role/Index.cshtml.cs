using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Account.Role
{
    
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public SelectList Roles;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public List<RoleViewModel> Role { get; set; }
        public IndexModel(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task OnGetAsync(AccountSearchModel searchModel)
        {
            Role = _roleManager.Roles
               .Select(role => new RoleViewModel
               {
                   Id = role.Id,
                   Name = role.Name,
                   PersianName = role.PersianRoleName
               })
               .ToList();
        }
    }
}
