using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace GeneralManagement.Application.Contracts.Certificate
{
    public class CertificateViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string IconString { get; set; }
        public string ImageString { get; set; }
        public string Description { get; set; }
        public long LanguageId { get; set; }

    }
}