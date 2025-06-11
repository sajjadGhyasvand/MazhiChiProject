using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticlePicture;
using BlogManagement.Application.Contracts.Articles;
using EventManagement.Application.Contracts.Events;
using EventManagement.Application.Contracts.EventsPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Events.Events
{
    public class EventsGalleryModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<EventsPictureViewModel> EvensPictures;
        public EventsPictureSearchModel SearchModel;
        public EventViewModel Event;

        private readonly IEventApplication _eventApplication;
        private readonly IEventsPictureApplication _eventsPictureApplication;

        public EventsGalleryModel(IEventApplication eventApplication, IEventsPictureApplication eventsPictureApplication)
        {
            _eventApplication = eventApplication;
            _eventsPictureApplication = eventsPictureApplication;
        }


        public void OnGet(long id)
        {
            Event = _eventApplication.GetEvents(id);
            EvensPictures = _eventsPictureApplication.ListBy(id);
        }

        public IActionResult OnGetCreatePicture(long id)
        {
            var command = new CreateEventsPicture()
            {
                EventId = id
            };
            return Partial("./CreatePicture", command);
        }

        public JsonResult OnPostCreatePicture(CreateEventsPicture commend)
        {
            var result = _eventsPictureApplication.Create(commend);
            return new JsonResult(result);
        }

        public IActionResult OnGetEditPicture(long id)
        {
            var picture = _eventsPictureApplication.GetDetails(id);
            picture.Events = _eventApplication.GetEventsList();
            return Partial("./EditPicture", picture);
        }
        public JsonResult OnPostEditPicture(EditPictureEvents commend)
        {
            var result = _eventsPictureApplication.Edit(commend);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _eventsPictureApplication.IsRemove(id);
            var events = _eventsPictureApplication.GetBy(id);
            if (result.IsSuccess)
                return RedirectToPage("./EventsGallery", new { id = events.EventsId});
            Message = result.Massage;
            return RedirectToPage("./EventsGallery", new { id = events.EventsId });
        }
        public IActionResult OnGetRestore(long id)
        
        {
            var result = _eventsPictureApplication.Restore(id);
            var events = _eventsPictureApplication.GetBy(id);
            if (result.IsSuccess)
                return RedirectToPage("./EventsGallery", new {id= events.EventsId });
            Message = result.Massage;
            return RedirectToPage("./EventsGallery", new { id = events.EventsId });
        }
    }
}
