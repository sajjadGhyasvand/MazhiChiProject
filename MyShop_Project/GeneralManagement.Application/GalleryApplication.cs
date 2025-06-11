using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Gallery;
using GeneralManagement.Domain.GalleryAgg;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application
{
    public class GalleryApplication :IGalleryApplication
    {
        private  readonly  IGalleryRepository _galleryRepository;
        private readonly IFileUploader _fileUploader;

        public GalleryApplication(IGalleryRepository galleryRepository, IFileUploader fileUploader)
        {
            _galleryRepository = galleryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateGallery command)
        {
            var operation = new OperationResult();
            if (_galleryRepository.Exists(x => x.Title == command.Title && x.LanguageId != command.LanguageId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slug();
            var path = $"Gallery\\{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, path);
            var generalSetting = new Gallery(command.Title,command.Description, fileName,command.PictureAlt,command.PictureTitle,command.LanguageId,slug);
            _galleryRepository.Create(generalSetting);
            _galleryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditGallery command)
        {
            var operation = new OperationResult();
            var gallery = _galleryRepository.Get(command.Id);
            if (gallery == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_galleryRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var path = $"Gallery\\{command.Title.Slug()}\\";
            var image = _fileUploader.FileUpload(command.Picture, path);
            gallery.Edit(command.Title,command.Description,image,command.PictureAlt,command.PictureTitle,command.LanguageId,command.Slug);
            _galleryRepository.SaveChanges();
            return operation.Success();
        }

        public EditGallery GetDetails(long id)
        {
            return _galleryRepository.GetDetails(id);
        }

        public List<GalleryViewModel> Search(GallerySearchModel searchModel)
        {
            return  _galleryRepository.Search(searchModel);
        }
    }
}