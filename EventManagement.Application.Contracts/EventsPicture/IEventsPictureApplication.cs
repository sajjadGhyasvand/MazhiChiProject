using System.Collections.Generic;
using EventManagement.Application.Contracts.Events;
using My_Shop_Framework.Application;

namespace EventManagement.Application.Contracts.EventsPicture
{
    public interface IEventsPictureApplication
    {
        OperationResult Create(CreateEventsPicture command);
        OperationResult Edit(EditPictureEvents command);
        OperationResult IsRemove(long id);
        OperationResult Restore(long id);
        EditPictureEvents GetDetails(long id);
        List<EventsPictureViewModel> Search(EventsPictureSearchModel model);
        List<EventsPictureViewModel> ListBy(long id);
        EventsPictureViewModel GetBy(long id);

    }
}