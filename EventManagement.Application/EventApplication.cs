
using System.Collections.Generic;
using System.Linq;
using EventManagement.Application.Contracts.Events;
using EventManagement.Domain.Event.Agg;
using My_Shop_Framework.Application;

namespace EventManagement.Application
{
    public class EventApplication : IEventApplication
    {
        private readonly IEventRepository _eventRepository;
        private readonly IFileUploader _fileUploader;

        public EventApplication(IFileUploader fileUploader, IEventRepository eventRepository)
        {
            _fileUploader = fileUploader;
            _eventRepository = eventRepository;
        }


        public OperationResult Create(CreateEvents command)
        {
            var operation = new OperationResult();
            if (_eventRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slug();
            var path = $"Events\\{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var articles = new Events(command.Title,command.ShortDescription,command.Description,fileName,command.PictureAlt,
                command.PictureTitle,slug,command.MetDescription,command.Keywords
                    , command.CanonicalAddress, publishDate, command.LanguageId);
            _eventRepository.Create(articles);
            _eventRepository.SaveChanges();
            return operation.Success();


        }

        public OperationResult Edit(EditEvents command)
        {
            var operation = new OperationResult();
            var article = _eventRepository.GetWithCategory(command.Id);
            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_eventRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slug();
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var path = $"Events\\{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, path);
            article.Edit(command.Title, command.ShortDescription, command.Description, fileName, command.PictureAlt,
                command.PictureTitle, slug, command.MetDescription, command.Keywords
                , command.CanonicalAddress, publishDate, command.LanguageId);
            _eventRepository.SaveChanges();
            return operation.Success();
        }

        public EditEvents GetDetails(long id)
        {
            return _eventRepository.GetDetails(id);
        }

        public List<EventViewModel> Search(EventSearchModel searchModel)
        {
            return _eventRepository.Search(searchModel);
        }

        public List<EventViewModel> GetEventsList()
        {
            return _eventRepository.GetEventsList().Select(x => new EventViewModel()
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }

        public EventViewModel GetEvents(long id)
        {
            return _eventRepository.GetEvents(id);
        }
    }
}