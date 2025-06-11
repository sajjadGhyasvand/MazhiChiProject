using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Areas.Admin.Pages.Account.Account
{
    public class UserApprovalModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessageService _smsService;
        public UserApprovalModel(UserManager<ApplicationUser> userManager, IMessageService smsService)
        {
            _userManager = userManager;
            _smsService=smsService;
        }

        public IList<ApplicationUser> PendingUsers { get; set; }

        public async Task OnGetAsync()
        {
            PendingUsers = await _userManager.Users
                .Where(u => !u.IsApproved)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostApproveAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsApproved = true;
                await _userManager.UpdateAsync(user);
                await _smsService.SendSms(SmsTemplate.acceptUser, user.PhoneNumber, $"{user.FirstName} {user.LastName}");
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDenyAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToPage();
        }
    }

}
