using System;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Models.Services

{
    public interface ILanguagesService
    {
        Language Add(CreateLanguageViewModel language);
        LanguagesViewModel All();
        LanguagesViewModel FindBy(LanguagesViewModel search);
        Language FindBy(int id);
        Language Edit(int id, Language language);
        bool Remove(int id);
    }
}