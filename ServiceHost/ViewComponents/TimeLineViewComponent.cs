using Microsoft.AspNetCore.Mvc;
using My_ShopQuery.Contract.AboutUs;
using My_ShopQuery.Contract.GeneralSetting;

namespace ServiceHost.ViewComponents
{
    public class TimeLineViewComponent : ViewComponent
    {
    

        public IViewComponentResult Invoke()
        {
            return View("TimeLine");
        }
    }
}