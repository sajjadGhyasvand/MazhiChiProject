using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace EventManagement.Application.Contracts.Events
{
    public interface IEventApplication
    {
        OperationResult Create(CreateEvents command);
        OperationResult Edit(EditEvents command);
        EditEvents GetDetails(long id);
        List<EventViewModel> Search(EventSearchModel searchModel);
        List<EventViewModel> GetEventsList();
        EventViewModel GetEvents(long id);
    }
}