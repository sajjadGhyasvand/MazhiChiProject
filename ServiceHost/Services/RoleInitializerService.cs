using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ServiceHost.Services
{

    public class RoleInitializerService : IRoleInitializerService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleInitializerService(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task InitializeAsync()
        {
            await AddRolesAsync();
            await CreateDefaultUsersAsync();
        }

        private async Task AddRolesAsync()
        {
            await CreateRoleIfNotExists("SuperAdmin", "مدیر سیستم");
            await CreateRoleIfNotExists("Admin", "ادمین");
            await CreateRoleIfNotExists("ManageUser", "لیست کاربران");
            await CreateRoleIfNotExists("RegularUser", "کاربر عادی");
            await CreateRoleIfNotExists("DistributionUser", "کاربر توزیع");
        }

        private async Task CreateRoleIfNotExists(string roleName, string persianName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new ApplicationRole
                {
                    Name = roleName,
                    PersianRoleName = persianName
                });
            }
        }

        private async Task CreateDefaultUsersAsync()
        {
            // Unknown User
            var unknownUser = await _userManager.FindByNameAsync("0");
            if (unknownUser == null)
            {
                await _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "0",
                    FirstName = "Unknown",
                    LastName = "User",
                    LockoutEnabled = false,
                }, "123@asdfA");
            }

            // Super Admin
            var superAdmin = await _userManager.FindByNameAsync("1");
            if (superAdmin == null)
            {
                await _userManager.CreateAsync(new ApplicationUser
                {
                    Email = "sajjadgh1995@hotmail.com",
                    UserName = "1",
                    FirstName = "Admin",
                    LastName = "System",
                    PhoneNumber = "09938011131",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                }, "123@asdfA");

                superAdmin = await _userManager.FindByNameAsync("1");
                await _userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
            }
        }
    }

}
