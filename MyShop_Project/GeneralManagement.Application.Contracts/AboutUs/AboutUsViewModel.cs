using My_Shop_Framework.Application;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GeneralManagement.Application.Contracts.AboutUs
{
    public class AboutUsViewModel
    {
        public long Id  { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string History { get; set; }
        public long LanguageId { get; set; }
        public string StringVideo { get; set; }
        public string StringPoster { get; set; }
    }
}