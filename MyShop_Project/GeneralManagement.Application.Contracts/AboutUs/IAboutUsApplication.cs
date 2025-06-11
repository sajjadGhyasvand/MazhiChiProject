using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.AboutUs
{
    public interface IAboutUsApplication
    {
        OperationResult Create(CreateAboutUs command);
        OperationResult Edit(EditAboutUs command);
        EditAboutUs GetDetails(long id);
        List<AboutUsViewModel> Search(AboutUsSearchModel model);

    }
}