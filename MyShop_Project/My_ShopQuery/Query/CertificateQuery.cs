using GeneralManagement.Infrastructure.EFCore;
using My_ShopQuery.Contract.Certificate;
using System.Globalization;

namespace My_ShopQuery.Query
{
    public class CertificateQuery : ICertificateQueryModel
    {
        private readonly GeneralContext _generalContext;

        public CertificateQuery(GeneralContext generalContext)
        {
            _generalContext = generalContext;
        }

        public CertificateQueryModel GetCertificate(long id)
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            return _generalContext.Certificates.Select(X => new CertificateQueryModel()
            {
                Title = X.Title,
                Description = X.Description,
                ImageString = X.Image,
                IconString = X.Logo,
                Id = X.Id,
                Pdf = X.PdfFile
            }).SingleOrDefault(x => x.Id == id);

        }

        public List<CertificateQueryModel> GetCertificateList()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            return _generalContext.Certificates.Select(X => new CertificateQueryModel()
            {
                Title = X.Title,
                Description = X.Description,
                ImageString = X.Image,
                IconString = X.Logo,
                Id = X.Id,
                LanguageId = X.LanguageId
            }).ToList();
        }

        public List<CertificateQueryModel> TakeCertificate()
        {
            var currentLanguage = CultureInfo.CurrentCulture.ToString();
            return _generalContext.Certificates.Select(X => new CertificateQueryModel()
            {
                Title = X.Title,
                Description = X.Description,
                ImageString = X.Image,
                IconString = X.Logo,
                Id = X.Id,
                LanguageId = X.LanguageId
            }).Take(3).ToList();
        }
    }
}