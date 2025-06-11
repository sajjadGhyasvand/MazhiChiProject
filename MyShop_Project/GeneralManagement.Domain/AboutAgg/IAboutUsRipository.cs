using System.Collections.Generic;
using GeneralManagement.Application.Contracts.AboutUs;
using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.AboutAgg
{
    public interface IAboutUsRepository:IRepository<long,AboutUs>
    {
        EditAboutUs GetDetails(long id);
        AboutUsViewModel GetAboutId();
        List<AboutUsViewModel> Search(AboutUsSearchModel model);
    }
}