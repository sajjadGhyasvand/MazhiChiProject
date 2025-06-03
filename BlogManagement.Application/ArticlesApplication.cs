using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlogManagement.Application.Contracts.Articles;
using BlogManagement.Domain.Articles.Agg;
using BlogManagement.Domain.ArticlesCategory.Agg;
using My_Shop_Framework.Application;

namespace BlogManagement.Application
{
    public class ArticlesApplication : IArticlesApplication
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly IArticlesCategoryRepository _articlesCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticlesApplication(IArticlesRepository articlesRepository, IFileUploader fileUploader, IArticlesCategoryRepository articlesCategoryRepository)
        {
            _articlesRepository = articlesRepository;
            _fileUploader = fileUploader;
            _articlesCategoryRepository = articlesCategoryRepository;
        }

        public OperationResult Create(CreateArticles command)
        {
            var operation = new OperationResult();
            if (_articlesRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slug();
            var path = $"Articles\\{_articlesCategoryRepository.GetSlugBy(command.CategoryId)}\\{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var articles = new Articles(command.Title, command.ShortDescription, command.Description, fileName,
                command.PictureAlt, command.PictureTitle, slug, command.MetDescription, command.Keywords,
                command.CanonicalAddress, command.CategoryId, publishDate,command.LanguageId,command.CommentActive);
            _articlesRepository.Create(articles);
            _articlesRepository.SaveChanges();
            return operation.Success();


        }

        public OperationResult Edit(EditArticles command)
        {
            var operation = new OperationResult();
            var article = _articlesRepository.GetWithCategory(command.Id);
            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            if (_articlesRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slug();
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var path = $"Articles\\{_articlesCategoryRepository.GetSlugBy(command.CategoryId)}\\{slug}\\";
            var fileName = _fileUploader.FileUpload(command.Picture, path);
            article.Edit(command.Title,command.ShortDescription,command.Description, fileName, command.PictureAlt,command.PictureTitle,slug,
                command.MetDescription,command.Keywords,command.CanonicalAddress,
                command.CategoryId, publishDate,command.LanguageId,command.CommentActive);
            _articlesRepository.SaveChanges();
            return operation.Success();
        }

        public EditArticles GetDetails(long id)
        {
            return _articlesRepository.GetDetails(id);
        }

        public List<ArticlesViewModel> Search(ArticlesSearchModel searchModel)
        {
            return _articlesRepository.Search(searchModel);
        }

        public List<ArticlesViewModel> GetArticles()
        {
            return _articlesRepository.GetArticles().Select(x => new ArticlesViewModel()
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }

        public ArticlesViewModel GetArticle(long id)
        {
            return _articlesRepository.GetArticle(id);
        }
    }
}