using GeneralManagement.Application.Contracts.Certificate;
using My_Shop_Framework.Application;
using System.Collections.Generic;

namespace GeneralManagement.Application.Contracts.Gallery
{
    public interface IGalleryApplication
    {
        OperationResult Create(CreateGallery command);
        OperationResult Edit(EditGallery command);
        EditGallery GetDetails(long id);
        List<GalleryViewModel> Search(GallerySearchModel searchModel);
    }
}