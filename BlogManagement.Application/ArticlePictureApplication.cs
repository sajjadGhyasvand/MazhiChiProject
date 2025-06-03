using System;
using System.Collections.Generic;
using System.IO;
using BlogManagement.Application.Contracts.ArticlePicture;
using BlogManagement.Domain.ArticlePicture.Agg;
using BlogManagement.Domain.Articles.Agg;
using BlogManagement.Domain.ArticlesCategory.Agg;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;

namespace BlogManagement.Application
{
    public class ArticlePictureApplication : IArticlePictureApplication
    {
        private readonly IArticlePictureRepository _articlePictureRepository;
        private readonly IArticlesRepository _articlesRepository;
        private readonly IArticlesCategoryRepository _articlesCategoryRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticlePictureApplication(IArticlePictureRepository articlePictureRepository, IArticlesRepository articlesRepository, IArticlesCategoryRepository articlesCategoryRepository, IFileUploader fileUploader, IHttpContextAccessor httpContextAccessor)
        {
            _articlePictureRepository = articlePictureRepository;
            _articlesRepository = articlesRepository;
            _articlesCategoryRepository = articlesCategoryRepository;
            _fileUploader = fileUploader;
            _httpContextAccessor = httpContextAccessor;
        }


        public OperationResult Create(CreateArticlePicture command)
        {
            var operation = new OperationResult();
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            if (command.ArticleId > 0)
            {
                var articles = _articlesRepository.GetDetails(command.ArticleId);
                var categorySlug = _articlesCategoryRepository.GetDetails(articles.CategoryId).Slug;
                var path = $"Articles\\{categorySlug}\\{Guid.NewGuid()}{Path.GetExtension(articles.Slug)}\\";
                var picture = _fileUploader.FileUpload(command.Picture, path);
              
                var link = $"{_httpContextAccessor.HttpContext.Request.Host.ToString()}/Images/{picture.Replace("\\" ,"/")}";
                var articlePicture = new ArticlePicture(command.ArticleId, picture, command.PictureAlt,
                    command.PictureTitle, link);
                _articlePictureRepository.Create(articlePicture);
                _articlePictureRepository.SaveChanges();
                return operation.Success();
            }
            return operation.Failed("????? ???? ??????");

        }

        public OperationResult Edit(EditArticlePicture command)
        {
            var operation = new OperationResult();
            var articlePicture = _articlePictureRepository.Get(command.Id);
            if (articlePicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            var articles = _articlesRepository.GetDetails(command.ArticleId);   
            var categorySlug = _articlesCategoryRepository.GetDetails(articles.CategoryId).Slug;
            var path = $"Articles\\{categorySlug}\\{articles.Slug}\\";
            var picture = _fileUploader.FileUpload(command.Picture, path);
 
            var link = $"{_httpContextAccessor.HttpContext.Request.Host.ToString()}\\Images\\{picture}";

            articlePicture.Edit(command.ArticleId, picture, command.PictureAlt, command.PictureTitle, link);
            _articlePictureRepository.SaveChanges();
            return operation.Success();

        }

        public OperationResult IsRemove(long id)
        {
            var operation = new OperationResult();
            var articlePicture = _articlePictureRepository.Get(id);
            if (articlePicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            articlePicture.Remove();
            _articlePictureRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var articlePicture = _articlePictureRepository.Get(id);
            if (articlePicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            articlePicture.Restore();
            _articlePictureRepository.SaveChanges();
            return operation.Success();
        }

        public EditArticlePicture GetDetails(long id)
        {
            return _articlePictureRepository.GetDetails(id);
        }

        public List<ArticlePictureViewModel> Search(ArticlePictureSearchModel model)
        {
            return _articlePictureRepository.Search(model);
        }

        public List<ArticlePictureViewModel> ListBy(long id)
        {
            return _articlePictureRepository.ListBy(id);
        }

        public ArticlePictureViewModel GetBy(long id)
        {
            return _articlePictureRepository.GetBy(id);
        }
    }
}