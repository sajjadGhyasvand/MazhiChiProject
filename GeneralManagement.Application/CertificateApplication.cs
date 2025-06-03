using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Certificate;
using GeneralManagement.Domain.CertificateAgg;
using My_Shop_Framework.Application;

namespace GeneralManagement.Application
{
    public class CertificateApplication:ICertificateApplication
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IFileUploader _fileUploader;

        public CertificateApplication(ICertificateRepository certificateRepository, IFileUploader fileUploader)
        {
            _certificateRepository = certificateRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateCertificate command)
        {
            var operation = new OperationResult();

            if (_certificateRepository.CheckerExist(command.LanguageId,command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var path = $"Certificate\\{command.Title.Slug()}\\";
            var logo = _fileUploader.FileUpload(command.Icon, path);
            var image = _fileUploader.FileUpload(command.Image, path);
            var pdfFile = _fileUploader.FileUpload(command.PdfFile, path);

            var certificate = new Certificate(command.Title,logo,image,command.Description, command.LanguageId, pdfFile);
            _certificateRepository.Create(certificate);
            _certificateRepository.SaveChanges();
            return operation.Success();
        }

        public OperationResult Edit(EditCertificate command)
        {
            var operation = new OperationResult();
            var certificate = _certificateRepository.Get(command.Id);
            if (certificate == null)
                return operation.Failed(ApplicationMessages.RecordNotFund);
            var path = $"Certificate\\{command.Title.Slug()}\\";
            var logo = _fileUploader.FileUpload(command.Icon, path);
            var image = _fileUploader.FileUpload(command.Image, path);
            var pdfFile = _fileUploader.FileUpload(command.PdfFile, path);
            certificate.Edit(command.Title, logo, image,command.Description,command.LanguageId, pdfFile);
            _certificateRepository.SaveChanges();
            return operation.Success();
        }

        public EditCertificate GetDetails(long id)
        {
            return _certificateRepository.GetDetails(id);
        }

        public List<CertificateViewModel> GetList()
        {
            return _certificateRepository.List();
        }

        public bool CheckerExist(long languageId, string name)
        {
            return _certificateRepository.CheckerExist(languageId, name);
        }
    }
}