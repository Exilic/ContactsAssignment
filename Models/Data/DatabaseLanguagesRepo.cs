using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mvc_week4849.Models.Database;

namespace mvc_week4849.Models.Data
{
    public class DatabaseLanguagesRepo : ILanguagesRepo
    {

        private readonly PeopleDbContext _peopleDbContext;

        public DatabaseLanguagesRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Language Create(string languageName, List<Person> people)
        {

            Language language = new Language(languageName);
            _peopleDbContext.LanguagesList.Add(language);
            if (_peopleDbContext.SaveChanges() > 0)
            {
                return language;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(Language language)
        {
            _peopleDbContext.LanguagesList.Remove(language);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Language> Read()
        {
            return _peopleDbContext.LanguagesList
                .Include(l => l.PersonLanguages)
                .ToList();
        }

        public Language Read(int id)
        {
            return _peopleDbContext.LanguagesList
                .Include(l => l.PersonLanguages)
                .SingleOrDefault(l => l.Id == id);
        }

        public Language Update(Language language)
        {
            _peopleDbContext.LanguagesList.Update(language);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return language;
            }
            else
            {
                return null;
            }
        }
    }
}
