using System.Collections.Generic;
using EventManagement.Application.Contracts.EventsPicture;
using EventManagement.Domain.Event.Agg;
using EventManagement.Domain.EventPicture;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace EventManagement.Application
{
    public class EventsApplication : IEventsPictureApplication
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventPictureRepository _eventPictureRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventsApplication(IEventRepository eventRepository, IEventPictureRepository eventPictureRepository, IFileUploader fileUploader, IHttpContextAccessor httpContextAccessor)
        {
            _eventRepository = eventRepository;
            _eventPictureRepository = eventPictureRepository;
            _fileUploader = fileUploader;
            _httpContextAccessor = httpContextAccessor;
        }


        public OperationResult Create(CreateEventsPicture command)
        {
            var operation = new OperationResult();
            //if (_eventPictureRepository.Exists(x => x.Picture == command.Picture && x.Id == command.EventId))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            if (command.EventId > 0)
            {
                var articles = _eventRepository.GetDetails(command.EventId);
                var path = $"\\{articles.Slug}\\";
                var picture = _fileUploader.FileUpload(command.Picture, path);

                var link = $"{_httpContextAccessor.HttpContext.Request.Host.ToString()}\\Images\\{picture}";
                var eventPicture = new EventPicture(command.EventId, picture, command.PictureAlt,
                    command.PictureTitle, link);
                _eventPictureRepository.Create(eventPicture);
                _eventPictureRepository.SaveChanges();
                return operation.Success();
            }
            return operation.Failed("مجددا تلاش نمایید");

        }

        public OperationResult Edit(EditPictureEvents command)
        {
            var operation = new OperationResult();
            var articlePicture = _eventPictureRepository.Get(command.Id);
            if (articlePicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            var articles = _eventRepository.GetDetails(command.EventId);
            var path = $"\\{articles.Slug}\\";
            var picture = _fileUploader.FileUpload(command.Picture, path);

            var link = $"{_httpContextAccessor.HttpContext.Request.Host.ToString()}\\Images\\{picture}";

            articlePicture.Edit(command.EventId, picture, command.PictureAlt, command.PictureTitle, link);
            _eventPictureRepository.SaveChanges();
            return operation.Success();

        }

        public OperationResult IsRemove(long id)
        {
            var operation = new OperationResult();
            var articlePicture = _eventPictureRepository.Get(id);
            if (articlePicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            articlePicture.Remove();
            _eventPictureRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var articlePicture = _eventPictureRepository.Get(id);
            if (articlePicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            articlePicture.Restore();
            _eventPictureRepository.SaveChanges();
            return operation.Success();
        }

        public EditPictureEvents GetDetails(long id)
        {
            return _eventPictureRepository.GetDetails(id);
        }

        public List<EventsPictureViewModel> Search(EventsPictureSearchModel model)
        {
            return _eventPictureRepository.Search(model);
        }


        public List<EventsPictureViewModel> ListBy(long id)
        {
            return _eventPictureRepository.ListBy(id);
        }

        public EventsPictureViewModel GetBy(long id)
        {
            return _eventPictureRepository.GetBy(id);
        }
    }
}