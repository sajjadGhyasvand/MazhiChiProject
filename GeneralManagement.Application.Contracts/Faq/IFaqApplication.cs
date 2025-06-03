using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application.Contracts.Faq
{
    public interface IFaqApplication
    {
        OperationResult Create(CreateFaq command);
        OperationResult Edit(EditFaq command);
        EditFaq GetDetails(long id);
        List<FaqViewModel> GetList();
        OperationResult IsRemove(long id);
        OperationResult Restore(long id);
    }
}