using System;
using System.Collections.Generic;
using mvc_week4849.Models.Data;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Models.Services
{
    public class LanguagesService : ILanguagesService
    {
        ILanguagesRepo _languagesRepo;

        public LanguagesService(ILanguagesRepo languagesRepo)
        {
            _languagesRepo = languagesRepo;
        }

        public Language Add(CreateLanguageViewModel language)
        {
            List<Person> peopleList = new List<Person>();
            return _languagesRepo.Create(language.LanguageName, peopleList);
        }

        public LanguagesViewModel All()
        {
            LanguagesViewModel languagesViewModel = new LanguagesViewModel();

            languagesViewModel.LanguagesList = _languagesRepo.Read();

            return languagesViewModel;
        }

        public Language Edit(int id, Language language)
        {
            Language editedLanguage = new Language() { Id = id, LanguageName = language.LanguageName };

            return _languagesRepo.Update(editedLanguage);
        }

        public LanguagesViewModel FindBy(LanguagesViewModel search)
        {
            if (search.Search != null)
            {
                foreach (var item in _languagesRepo.Read())
                {
                    if (item.LanguageName.Contains(search.Search))
                    {
                        search.LanguagesList.Add(item);
                    }
                }
            }
            else { search.LanguagesList = _languagesRepo.Read(); }

            return search;
        }

        public Language FindBy(int id)
        {
            return _languagesRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Language language = _languagesRepo.Read(id);
            if (language == null)
            {
                return false;
            }
            else
            {
                _languagesRepo.Delete(language);
                return true;
            }
        }
    }
}
