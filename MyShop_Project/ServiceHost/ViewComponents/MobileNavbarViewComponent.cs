using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.GeneralSetting;
using My_ShopQuery.Contract.Menu;
using My_ShopQuery.Contract.SiteLogo;
using My_ShopQuery.Contract.SocialMedia;

namespace ServiceHost.ViewComponents
{
    public class MobileNavbarViewComponent : ViewComponent
    {
        private readonly ISiteLogoQueryModel _siteLogoQueryModel;
        private readonly ISocialMediaQueryModel _socialMediaQuery;
        private readonly IGeneralSettingQueryModel _generalSettingQueryModel;


        public MobileNavbarViewComponent( ISiteLogoQueryModel siteLogoQueryModel, ISocialMediaQueryModel socialMediaQuery, IGeneralSettingQueryModel generalSettingQueryModel)
        {

            _siteLogoQueryModel = siteLogoQueryModel;
            _socialMediaQuery = socialMediaQuery;
            _generalSettingQueryModel = generalSettingQueryModel;
        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuQueryModel
            {
                SiteLogoQueryModel = _siteLogoQueryModel.GetLogo(),
                SocialMediaQueries = _socialMediaQuery.SocialMediaList(),
                GeneralSettingQuery = _generalSettingQueryModel.GeneralSettingQueryModel()
            };
            return View("MobileNavbar", result);
        }

    }
}
