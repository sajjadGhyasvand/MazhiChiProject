using System.Globalization;
using System.Linq;
using GeneralManagement.Infrastructure.EFCore;

using My_ShopQuery.Contract.GeneralSetting;

namespace My_ShopQuery.Query
{
    public class GeneralSettingQuery : IGeneralSettingQueryModel
    {
        private readonly GeneralContext _context;

        public GeneralSettingQuery(GeneralContext context)
        {
            _context = context;
        }

        public GeneralSettingQueryModel GeneralSettingQueryModel()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();


            var general = _context.GeneralSettings
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