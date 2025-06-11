

using System.Collections.Generic;
using GeneralManagement.Application.Contracts.Certificate;
using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.CertificateAgg
{
    public interface ICertificateRepository : IRepository<long, Certificate>
    {
        EditCertificate GetDetails(long id);
        List<CertificateViewModel> List();
        bool CheckerExist(long languageId,string name);
    }
}