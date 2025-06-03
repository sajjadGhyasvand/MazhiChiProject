using System.Globalization;
using System.Linq;
using LanguageManagement.Application.Contracts.Language;
using LanguageManagement.Domain.Language.Agg;
using My_Shop_Framework.Application;

namespace LanguageManagement.Infrastructure.EFCore
{
    public class LibraryInitializerLanguage
    {
        private readonly ILanguageApplication _languageApplication;
        private readonly ILanguageRepository _languageRepository
            ;

        public LibraryInitializerLanguage(ILanguageApplication languageApplication, ILanguageRepository languageRepository)
        {
            _languageApplication = languageApplication;
            _languageRepository = languageRepository;
        }


        public void Initialize()
        {

            var language = _languageApplication.List();
            if (language.All(u => u.LanguageTitle != "en-US"))
            {
                _languageApplication.Create(new CreateLanguage
                {
                    LanguageTitle = "en-US",
                    LanguageNameEn = "English",
                    LanguageNameAr = "إنجليزي",
                });

            }

            _languageRepository.SaveChanges();

        }
    }
}