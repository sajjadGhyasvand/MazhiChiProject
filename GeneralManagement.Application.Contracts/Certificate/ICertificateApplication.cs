using GeneralManagement.Application.Contracts.GeneralSetting;
using My_Shop_Framework.Application;
using System.Collections.Generic;

namespace GeneralManagement.Application.Contracts.Certificate
{
    public interface ICertificateApplication
    {
        OperationResult Create(CreateCertificate command);
        OperationResult Edit(EditCertificate command);
        EditCertificate GetDetails(long id);
        List<CertificateViewModel> GetList();
        bool CheckerExist(long languageId, string name);
    }
}