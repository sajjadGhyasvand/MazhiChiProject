using System.Collections.Generic;
using EventManagement.Application.Contracts.EventsPicture;
using EventManagement.Domain.Event.Agg;
using My_Shop_Framework.Domain;

namespace EventManagement.Domain.EventPicture
{
    public interface IEventPictureRepository : IRepository<long, EventPicture>
    {
        EditPictureEvents GetDetails(long id);
        List<EventsPictureViewModel> Search(EventsPictureSearchModel searchModel);
        List<EventsPictureViewModel> ListBy(long id);
        EventsPictureViewModel GetBy(long id);
    }
}