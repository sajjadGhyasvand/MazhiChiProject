using System;
using System.Collections.Generic;
using System.Linq;
using EventManagement.Application.Contracts.Events;
using EventManagement.Domain.Event.Agg;
using My_Shop_Framework.Application;
using My_Shop_Framework.Infrastructure;


namespace EventManagement.Infrastructure.EFCore.Repository
{
    public class EventsRepository : RepositoryBase<long, Events>, IEventRepository
    {
        private readonly EventContext _eventContext;
        public EventsRepository(EventContext eventContext) : base(eventContext)
        {
            _eventContext = eventContext;
        }

        public EditEvents GetDetails(long id)
        {
            return _eventContext.Events.Select(x => new EditEvents
            {
                Slug = x.Slug,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureString = x.Picture,
                PictureTitle = x.PictureTitle,
                Keywords = x.Keywords,
                LanguageId = x.LanguageId,
                ShortDescription = x.ShortDescription.Substring(0,Math.Min(x.ShortDescription.Length,50))+"...",
                MetDescription = x.MetDescription,
                PublishDate = x.PublishDate.ToString(),
                Title = x.Title
            }).SingleOrDefault(x => x.Id == id);
        }

        public Events GetWithCategory(long id)
        {
            return _eventContext.Events.FirstOrDefault(x => x.Id == id);
        }

        public List<EventViewModel> Search(EventSearchModel searchModel)
        {
            var query = _eventContext.Events.Select(x => new EventViewModel
            {
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDateTime.ToFarsi(),
                PublishDate = x.PublishDate.ToFarsi(),
                Title = x.Title,
                Id = x.Id,
                LanguageId = x.LanguageId,
                Picture = x.Picture

            });
            if ((!string.IsNullOrWhiteSpace(searchModel.Title)))
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            if (searchModel.LanguageId > 0)
                query = query.Where(x => x.LanguageId == searchModel.LanguageId);

            return query.OrderByDescending(x => x.Id).ToList();
        }


        public EventViewModel GetEvents(long id)
        {
            return 
                _eventContext.Events.Select(x => new EventViewModel()
            {
                Id = x.Id,
                Title = x.Title,
            }).SingleOrDefault(x => x.Id == id);
        }

        public List<EventViewModel> GetEventsList()
        {
            return _eventContext.Events.Select(x => new EventViewModel()
            {
                Id = x.Id,
                Title = x.Title

            }).ToList();
        }
    }
}