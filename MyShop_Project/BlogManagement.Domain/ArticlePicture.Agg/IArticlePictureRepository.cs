using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticlePicture;
using My_Shop_Framework.Domain;

namespace BlogManagement.Domain.ArticlePicture.Agg
{
    public interface IArticlePictureRepository:IRepository<long, ArticlePicture>
    {
        EditArticlePicture GetDetails(long id);
        List<ArticlePictureViewModel> Search(ArticlePictureSearchModel searchModel);
        List<ArticlePictureViewModel> ListBy(long id);
        ArticlePictureViewModel GetBy(long id);
    }
}