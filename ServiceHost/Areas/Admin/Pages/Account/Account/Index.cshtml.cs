using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.Account.Agg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Application;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceHost.Areas.Admin.Pages.Account.Account
{

    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        [BindProperty]
        [Required]
        public string UserName { get; set; }

        [BindProperty]
        [Required, EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Phone]
        public string PhoneNumber { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        /* public List<AccountViewModel> Accounts;*/
        public List<ApplicationUser> Users { get; private set; }
        public AccountSearchModel Search;
        public SelectList Roles;
        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public List<string> SelectedRoles { get; set; } = new List<string>();
        [BindProperty]
        public ChangePassword changePasswordCommand { get; set; }
        public IndexModel(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IRoleApplication roleApplication, IAccountApplication accountApplication)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleApplication = roleApplication;
            _accountApplication = accountApplication;
        }

        public async Task OnGet(AccountSearchModel searchModel)
        {
            /*Roles = new SelectList(_roleApplication.GetRoles(), "Id", "Name");
            Accounts = _accountApplication.Search(searchModel);*/
            Users = await _userManager.Users.ToListAsync();
        }
        public IActionResult OnGetCreate()
        {
            var command = new RegisterAccount
            {
                Roles = _roleManager.Roles.Select(role => new RoleViewModel
                {
                    Id = role.Id.ToString(),
                    Name = role.Name.ToString(),
                    PersianName = role.PersianRoleName.ToString(),
                    CreationDate = DateTime.Now.ToString()
                }).ToList(),
            };
            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostCreate(RegisterAccount commend)
        {
            if (!ModelState.IsValid)
            {
                var command = new RegisterAccount
                {
                    AllRoles = _roleManager.Roles.Select(r => r.Name).ToList(),
                };
                return new JsonResult(null);
            }
            var user = new ApplicationUser
            {
                FirstName = commend.FirstName,
                LastName = commend.LastName,
                UserName = commend.UserName,
                Email = commend.Email,
                PhoneNumber = commend.PhoneNumber,
                CreateDate = DateTime.Now,
                PhoneNumberConfirmed = true,
                IsApproved = true,
                EmailConfirmed = true,
                ProfilePhotoPath = commend.PictureString
            };
            if (commend.ProfilePhoto != null)
            {
                var filePath = Path.Combine("wwwroot/Images/ProfilePhotos/", commend.ProfilePhoto.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await commend.ProfilePhoto.CopyToAsync(stream);
                }
                user.ProfilePhotoPath = $"/Images/ProfilePhotos/{commend.ProfilePhoto.FileName}";
            }
            

            var result = await _userManager.CreateAsync(user, Password);
            var operation = new OperationResult();
            if (result.Succeeded)
            {
                var addToRolesResult = await _userManager.AddToRolesAsync(user, SelectedRoles);


                return new JsonResult(operation.Success());
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return new JsonResult(null);
        }


        public async Task<IActionResult> OnGetEdit(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound();
            }

            var roles = _roleManager.Roles.Select(role => new RoleViewModel
            {
                Id = role.Id.ToString(),
                Name = role.Name,
                PersianName = role.PersianRoleName
            }).ToList();

            var selectedRoles = _userManager.GetRolesAsync(user).Result;

            var model = new EditAccount
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                PictureString = user.ProfilePhotoPath,
                Roles = roles,
                SelectedRoles = selectedRoles.ToList(),
                
            };

            return Partial("./Edit", model);
        }

        public async Task<JsonResult> OnPostEdit(EditAccount command)
        {
            
            var user = await _userManager.FindByNameAsync(command.UserName);
            if (user == null)
            {
                return new JsonResult(null);
            }
            if (command.ProfilePhoto != null)
            {
                if (!string.IsNullOrEmpty(user.ProfilePhotoPath))
                {
                    var oldImagePath = Path.Combine("wwwroot", user.ProfilePhotoPath.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(command.ProfilePhoto.FileName);
                var filePath = Path.Combine("wwwroot/Images/ProfilePhotos/", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await command.ProfilePhoto.CopyToAsync(stream);
                }
                user.ProfilePhotoPath = $"/Images/ProfilePhotos/{fileName}";
            }
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.UserName = command.UserName;
            user.Email = command.Email;
            user.PhoneNumber = command.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, command.SelectedRoles);
                return new JsonResult(new OperationResult().Success());
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return new JsonResult(null);
        }
        public async Task<IActionResult> OnGetChangePassword(string userName)
        {
            changePasswordCommand = new ChangePassword();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound();
            }

            changePasswordCommand.UserName = user.UserName;

            return Partial("./ChangePassword", changePasswordCommand);
        }

        public async Task<JsonResult> OnPostChangePassword(ChangePassword commend)
        {
            if (commend.Password != commend.RePassword)
            {
                return new JsonResult(new OperationResult().Failed(ApplicationMessages.PasswordNotMatch));
            }

            var user = await _userManager.FindByNameAsync(commend.UserName);
            if (user == null)
            {
                return new JsonResult(new OperationResult().Failed(ApplicationMessages.RecordNotFund));
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, commend.Password);

            if (result.Succeeded)
            {
                return new JsonResult(new OperationResult().Success());
            }

            var errors = result.Errors.Select(e => e.Description).ToList();
            return new JsonResult(new OperationResult().Failed("Password update failed"));
        }


        /*public async Task<JsonResult> OnPostChangePassword(ChangePassword commend)
        {

            var user = await _userManager.FindByNameAsync(commend.UserName);
            if (user == null)
                return new JsonResult(new OperationResult().Failed(ApplicationMessages.RecordNotFund));

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, commend.Password);
            if (commend.Password != commend.RePassword)
                return new JsonResult(new OperationResult().Failed(ApplicationMessages.PasswordNotMatch));
            if (result.Succeeded)
                return new JsonResult(new OperationResult().Success());
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return new JsonResult(new OperationResult().Failed("Password update failed"));

            *//* var result = _accountApplication.ChangePassword(commend);
             return new JsonResult(result);*//*
        }*/

    }
}
