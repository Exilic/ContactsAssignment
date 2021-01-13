using System;
using System.Collections.Generic;

namespace mvc_week4849.Models.Data
{
    public interface ILanguagesRepo
    {
        Language Create(string languageName, List<Person> people);
        List<Language> Read();
        Language Read(int id);
        Language Update(Language language);
        bool Delete(Language language);
    }
}