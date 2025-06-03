using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GeneralManagement.Application.Contracts.Certificate;
using GeneralManagement.Application.Contracts.SocialMedia;
using GeneralManagement.Domain.CertificateAgg;
using GeneralManagement.Domain.SocialMediaAgg;
using Microsoft.EntityFrameworkCore;
using My_Shop_Framework.Infrastructure;

namespace GeneralManagement.Infrastructure.EFCore.Repository
{
    public class CertificateRepository:RepositoryBase<long, Certificate>,ICertificateRepository
    {
        private readonly GeneralContext _generalContext;
        public CertificateRepository(GeneralContext generalContext) : base(generalContext)
        {
            _generalContext = generalContext;
        }

        public EditCertificate GetDetails(long id)
        {
            return _generalContext.Certificates.Select(x => new EditCertificate()
            {
                Id = x.Id,
                Title = x.Title,
                IconString = x.Logo,
                ImageString = x.Image,
                Description = x.Description,
                LanguageId = x.LanguageId,
                

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CertificateViewModel> List()
        {
            return _generalContext.Certificates.Select(x => new CertificateViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                IconString = x.Logo,
                ImageString = x.Image,
                Description = x.Description
            }).ToList();
        }

        public bool CheckerExist(long languageId, string name)
        {
            return _generalContext.Certificates.Any(x => x.LanguageId == languageId && x.Title == name);
        }
    }
}