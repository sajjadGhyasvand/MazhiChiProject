using GeneralManagement.Application.Contracts.GeneralSetting;
using My_Shop_Framework.Domain;
using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Gallery;

namespace GeneralManagement.Domain.GalleryAgg
{
    public interface IGalleryRepository:IRepository<long, Gallery>
    {
         EditGallery GetDetails(long id);
         List<GalleryViewModel> Search(GallerySearchModel model);
    }
}