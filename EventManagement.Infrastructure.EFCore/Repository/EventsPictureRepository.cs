using EventManagement.Application.Contracts.EventsPicture;
using EventManagement.Domain.EventPicture;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using My_Shop_Framework.Application;

namespace EventManagement.Infrastructure.EFCore.Repository
{
    public class EventsPictureRepository : RepositoryBase<long, EventPicture>, IEventPictureRepository
    {
        private readonly EventContext _context;

        public EventsPictureRepository(EventContext context) : base(context)
        {
            _context = context;
        }

        public EditPictureEvents GetDetails(long id)
        {
            return _context.EventPictures.Select(x => new EditPictureEvents
            {
                Id = x.Id,
                PictureString = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                EventId = x.EventId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<EventsPictureViewModel> Search(EventsPictureSearchModel searchModel)
        {
            var query = _context.EventPictures.Include(x => x.Events).Select(x => new EventsPictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Events = x.Events.Title,
                EventsId = x.EventId,
                IsRemoved = x.IsRemoved,
                Link = x.Link,
            }).ToList();
            if (searchModel.EventsId != 0)
                query = query.Where(x => x.EventsId == searchModel.EventsId).ToList();

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<EventsPictureViewModel> ListBy(long id)
        {
            return _context.EventPictures.Include(x => x.Events).Select(x => new EventsPictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Events = x.Events.Title,
                EventsId = x.EventId,
                IsRemoved = x.IsRemoved,
                PictureTitle = x.PictureTitle,
                Link = x.Link,
            }).Where(x => x.EventsId == id).ToList();
        }

        public EventsPictureViewModel GetBy(long id)
        {
            return _context.EventPictures.Include(x => x.Events).Select(x => new EventsPictureViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate = x.CreationDateTime.ToFarsi(),
                Events = x.Events.Title,
                EventsId = x.EventId,
                IsRemoved = x.IsRemoved,
                PictureTitle = x.PictureTitle,
                Link = x.Link
            }).SingleOrDefault(x => x.Id == id);
        }
    }
}