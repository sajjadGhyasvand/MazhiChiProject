using My_Shop_Framework.Domain;

namespace GeneralManagement.Domain.CertificateAgg
{
    public class Certificate : EntityBase
    {
        public string Title { get; private set; }
        public string Logo { get; private set; }
        public string Image { get; private set; }
        public string PdfFile { get; private set; }
        public string Description { get; private set; }
        public long LanguageId { get; private set; }

        public Certificate(string title, string logo, string image, string description, long languageId, string pdfFile)
        {
            Title = title;
            Logo = logo;
            Image = image;
            Description = description;
            LanguageId = languageId;
            PdfFile = pdfFile;
        }

        public void Edit(string title, string logo, string image, string description, long languageId, string pdfFile)
        {
            Title = title;
            if (!string.IsNullOrWhiteSpace(logo))
                Logo = logo;
            if (!string.IsNullOrWhiteSpace(image))
                Image = image;
            if(!string.IsNullOrWhiteSpace(pdfFile))
                PdfFile = pdfFile;
            Description = description;
            LanguageId = languageId;
        }
    }
}