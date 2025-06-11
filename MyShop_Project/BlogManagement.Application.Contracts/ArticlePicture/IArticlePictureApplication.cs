using System.Collections.Generic;
using My_Shop_Framework.Application;

namespace BlogManagement.Application.Contracts.ArticlePicture
{
    public interface IArticlePictureApplication
    {
        OperationResult Create(CreateArticlePicture command);
        OperationResult Edit(EditArticlePicture command);
        OperationResult IsRemove(long id);
        OperationResult Restore(long id);
        EditArticlePicture GetDetails(long id);
        List<ArticlePictureViewModel> Search(ArticlePictureSearchModel model);
        List<ArticlePictureViewModel> ListBy(long id);
        ArticlePictureViewModel GetBy(long id);

    }
}