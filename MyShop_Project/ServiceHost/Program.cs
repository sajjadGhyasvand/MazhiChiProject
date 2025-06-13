using AccountManagement.Configuration;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Infrastructure.EFCore;
using BlogManagement.Configuration;
using CommentManagement.Configuration;
using GeneralManagement.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using My_Shop_Framework.Application;
using My_Shop_Framework.Application.ZarinPal;
using ServiceHost;
using ServiceHost.Model;
using ServiceHost.Utils;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// --- ConfigureServices equivalent ---

// IIS & Kestrel limits
builder.Services.Configure<IISServerOptions>(opts =>
    opts.MaxRequestBodySize = 92_428_800);
builder.Services.Configure<KestrelServerOptions>(opts =>
    opts.Limits.MaxRequestBodySize = 92_428_800);

// scoped SignInManager override
builder.Services.AddScoped<SignInManager<ApplicationUser>, CustomSignInManager>();

// Identity setup
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddRoleManager<RoleManager<ApplicationRole>>()
    .AddSignInManager<CustomSignInManager>()
    .AddEntityFrameworkStores<AccountContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<CustomIdentityErrorDescriber>();

builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.Password.RequireDigit = true;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequiredLength = 5;
    opts.User.RequireUniqueEmail = true;
    opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    opts.Lockout.MaxFailedAccessAttempts = 5;
    opts.Lockout.AllowedForNewUsers = true;
    opts.SignIn.RequireConfirmedEmail = false;
    opts.SignIn.RequireConfirmedAccount = false;
    opts.SignIn.RequireConfirmedPhoneNumber = true;
});

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.Cookie.HttpOnly = true;
    opts.LoginPath = "/AccountRegister/Login";
    opts.AccessDeniedPath = "/Identity/Account/AccessDenied";
    opts.ExpireTimeSpan = TimeSpan.FromMinutes(40);
    opts.SlidingExpiration = true;
});

// Authorization policies
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("SuperAdmin", p => p.RequireRole("SuperAdmin"));
    opts.AddPolicy("UserPanel", p => p.RequireRole("SuperAdmin", "Admin", "DistributionUser"));
    opts.AddPolicy("Admin", p => p.RequireRole("SuperAdmin", "Admin"));
    opts.AddPolicy("UsersList", p => p.RequireRole("SuperAdmin", "Admin", "ManageUser"));
});

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Module bootstrappers
var conn = builder.Configuration.GetConnectionString("MazhiChi_Db")!;
ShopManagementBoostStrapper.Configure(builder.Services, conn);
BlogManagementBootStrapper.Configure(builder.Services, conn);
CommentManagementBoostStrapper.Configure(builder.Services, conn);
AccountManagementBootStrapper.Configure(builder.Services, conn);
GeneralManagementBootStrapper.Configure(builder.Services, conn);



// Utilities
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<EmailSender>();
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
builder.Services.AddScoped<LibraryInitializer>();



// Localization & MVC
builder.Services.AddLocalization(opts => opts.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opt => opt.ResourcesPath = "Resources")
    .AddDataAnnotationsLocalization(opts =>
        opts.DataAnnotationLocalizerProvider = (type, fac) => fac.Create(typeof(ShareResource)));
builder.Services.AddRazorPages();

var app = builder.Build();

// --- Configure equivalent ---

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseStatusCodePagesWithReExecute("/NotFound");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Seed roles & initialize
/*await SeedRolesAsync(app.Services);*/

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<LibraryInitializer>()
         .Initialize();
}

await app.RunAsync();

static async Task SeedRolesAsync(IServiceProvider services)
{
    var roleMgr = services.GetRequiredService<RoleManager<ApplicationRole>>();
    var userMgr = services.GetRequiredService<UserManager<ApplicationUser>>();

    async Task EnsureRole(string name, string persian)
    {
        if (!await roleMgr.RoleExistsAsync(name))
            await roleMgr.CreateAsync(new ApplicationRole
            {
                Name = name,
                PersianRoleName = persian
            });
    }

    await EnsureRole("SuperAdmin", "مدیر سیستم");
    await EnsureRole("Admin", "ادمین");
    await EnsureRole("ManageUser", "لیست کاربران");
    await EnsureRole("RegularUser", "کاربر عادی");
    await EnsureRole("DistributionUser", "کاربر توزیع");

    const string email = "sajjadgh1995@hotmail.com";
    const string pass = "123@asdfA";

    var admin = await userMgr.FindByEmailAsync(email);
    if (admin == null)
    {
        admin = new ApplicationUser
        {
            Email = email,
            UserName = "1",
            FirstName = "Admin",
            LastName = "System",
            PhoneNumber = "09938011131",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        await userMgr.CreateAsync(admin, pass);
    }
    await userMgr.AddToRoleAsync(admin, "SuperAdmin");

    // Unknown user
    var unknown = await userMgr.FindByNameAsync("0");
    if (unknown == null)
    {
        unknown = new ApplicationUser
        {
            UserName = "0",
            FirstName = "Unknown",
            LastName = "User",
            LockoutEnabled = false
        };
        await userMgr.CreateAsync(unknown, pass);
    }
}
