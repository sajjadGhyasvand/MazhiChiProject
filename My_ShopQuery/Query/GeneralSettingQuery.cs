using System.Globalization;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;
using LanguageManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.GeneralSetting;

namespace My_ShopQuery.Query
{
    public class GeneralSettingQuery : IGeneralSettingQueryModel
    {
        private readonly GeneralContext _context;
        private readonly LanguageContext _languageContext;

        public GeneralSettingQuery(GeneralContext context, LanguageContext languageContext)
        {
            _context = context;
            _languageContext = languageContext;
        }

        public GeneralSettingQueryModel GeneralSettingQueryModel()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();

            var language = _languageContext.Languages
                .FirstOrDefault(x => x.LanguageTitle == currentLanguage);

            if (language == null)
            {
                // اگر زبان پیدا نشد، یک آبجکت خالی بازگردانید
                return new GeneralSettingQueryModel();
            }

            var general = _context.GeneralSettings
                .Where(x => x.LanguageId == language.Id)
                .Select(x => new GeneralSettingQueryModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    LanguageId = x.LanguageId,
                    PhoneNumbers = x.PhoneNumbers,
                    PostalCode = x.PostalCode,
                    SiteTitle = x.SiteTitle,
                    Email = x.AdminEmail,
                    MapLink = x.MapLink,
                    MetaDescription = x.MetaDescription,
                    MetaKeywords = x.MetaKeywords,
                    BaladLink = x.BaladLink,
                    WaysLink = x.WaysLink,
                    GoogleLink = x.GoogleLink
                })
                .SingleOrDefault();

            return general ?? new GeneralSettingQueryModel();
        }

    }
}