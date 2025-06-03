using System.Collections.Generic;
using EventManagement.Application.Contracts.Events;
using My_Shop_Framework.Domain;

namespace EventManagement.Domain.Event.Agg
{
    public interface IEventRepository : IRepository<long, Events>
    {
        EditEvents GetDetails(long id);
        Events GetWithCategory(long id);
        List<EventViewModel> Search(EventSearchModel searchModel);
        EventViewModel GetEvents(long id);
        List<EventViewModel> GetEventsList();
    }
}