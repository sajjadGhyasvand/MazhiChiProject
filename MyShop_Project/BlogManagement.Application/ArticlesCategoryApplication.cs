using System.Collections.Generic;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticlesCategory.Agg;
using My_Shop_Framework.Application;

namespace BlogManagement.Application
{
    public class ArticlesCategoryApplication : IArticlesCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticlesCategoryRepository _articlesCategoryRepository;

        public ArticlesCategoryApplication(IArticlesCategoryRepository articlesCategoryRepository, IFileUploader fileUploader)
        {
            _articlesCategoryRepository = articlesCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticlesCategory command)
        {
            var operation = new OperationResult();
            if (_articlesCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slug();
            var picturePath = $"Articles\\{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, picturePath);
            var articlesCategory = new ArticlesCategory(command.Name, fileName, command.PictureAlt, 
                command.PictureTitle, command.Description, command.MetaDescription, command.CanonicalAddress,
                command.Slug, command.Keywords, command.ShowOrder,command.LanguageId);
            _articlesCategoryRepository.Create(articlesCategory);
            _articlesCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditArticlesCategory command)
        {
            var operation = new OperationResult();
            var articulateCategory = _articlesCategoryRepository.Get(command.Id);
            if (articulateCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_articlesCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slug();
            var picturePath = $"Articles\\{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, picturePath);
            articulateCategory.Edit(command.Name,fileName,command.PictureAlt,
                command.PictureTitle,command.Description,command.MetaDescription,
                command.CanonicalAddress,command.Slug,command.Keywords,command.ShowOrder, command.LanguageId);
            _articlesCategoryRepository.SaveChanges();
            return operation.Success();
        }

        public EditArticlesCategory GetDetails(long id)
        {
            return _articlesCategoryRepository.GetDetails(id);
        }

        public List<ArticlesCategoryViewModel> GetArticlesCategory()
        {
            return _articlesCategoryRepository.GetArticlesCategory();
        }

        public List<ArticlesCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articlesCategoryRepository.Search(searchModel);
        }

    }
}