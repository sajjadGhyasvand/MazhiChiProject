using AccountManagement.Configuration;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Infrastructure.EFCore;
using BlogManagement.Configuration;
using CommentManagement.Configuration;
using EventManagement.Configuration;
using GeneralManagement.Configuration;
using LanguageManagement.Application.Contracts.Language;
using LanguageManagement.Configuration;
using LanguageManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using My_Shop_Framework.Application;
using My_Shop_Framework.Application.ZarinPal;
using ServiceHost;
using ServiceHost.Model;
using ServiceHost.Utils;
using ShopManagement.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var env = builder.Environment;

// Request body limits
services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 92428800;
});
services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 92428800;
});

// Identity & Authentication
services.AddScoped<SignInManager<ApplicationUser>, CustomSignInManager>();

services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddRoleManager<RoleManager<ApplicationRole>>()
    .AddSignInManager<CustomSignInManager>()
    .AddEntityFrameworkStores<AccountContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<CustomIdentityErrorDescriber>();

services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.User.RequireUniqueEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.SignIn.RequireConfirmedPhoneNumber = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
});

services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/AccountRegister/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(40);
    options.SlidingExpiration = true;
});

// Authorization policies
services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));
    options.AddPolicy("UserPanel", policy => policy.RequireRole("SuperAdmin", "Admin", "DistributionUser"));
    options.AddPolicy("Admin", policy => policy.RequireRole("SuperAdmin", "Admin"));
    options.AddPolicy("UsersList", policy => policy.RequireRole("SuperAdmin", "Admin", "ManageUser"));
});

// Other services
services.AddHttpContextAccessor();
var connectionString = configuration.GetConnectionString("MazhiChi_Db");

ShopManagementBoostStrapper.Configure(services, connectionString);
BlogManagementBootStrapper.Configure(services, connectionString);
CommentManagementBoostStrapper.Configure(services, connectionString);
AccountManagementBootStrapper.Configure(services, connectionString);
LanguageManagementBootStrapper.Configure(services, connectionString);
GeneralManagementBootStrapper.Configure(services, connectionString);
EventManagementBootStrapper.Configure(services, connectionString);

services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
services.AddSingleton<IPasswordHasher, PasswordHasher>();
services.AddSingleton<EmailSender>();
services.AddTransient<IFileUploader, FileUploader>();
services.AddTransient<IZarinPalFactory, ZarinPalFactory>();

services.AddScoped<LibraryInitializer>();
services.AddScoped<LibraryInitializerLanguage>();

// Localization
services.AddLocalization(option => option.ResourcesPath = "Resources");

services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opt => opt.ResourcesPath = "Resources")
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(ShareResource));
    });

services.AddRazorPages();

var app = builder.Build();
builder.WebHost.UseStaticWebAssets();
// Configure HTTP request pipeline
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

// Localization setup
using (var scope = app.Services.CreateScope())
{
    var languageApp = scope.ServiceProvider.GetRequiredService<ILanguageApplication>();
    var languages = languageApp.List();
    var supportedCultures = languages.Select(x => new CultureInfo(x.LanguageTitle)).ToList();

    var localizationOptions = new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture("en-US"),
        SupportedCultures = supportedCultures,
        SupportedUICultures = supportedCultures,
        RequestCultureProviders = new List<IRequestCultureProvider>
        {
            new QueryStringRequestCultureProvider(),
            new CookieRequestCultureProvider()
        }
    };

    app.UseRequestLocalization(localizationOptions);
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<LibraryInitializer>();
    initializer.Initialize();
}

// Optional: CreateUserRoles
// await CreateUserRoles(app.Services);

app.Run();
