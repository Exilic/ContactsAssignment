using System;
using System.Collections.Generic;

namespace mvc_week4849.Models.ViewModels
{
    public class LanguagesViewModel
    {
        public List<Language> LanguagesList { get; set; }
        public List<Person> PeopleList { get; set; }
        public string Search { get; set; }

        public CreateLanguageViewModel CreateLanguage { get; set; }

        public LanguagesViewModel()
        {
            LanguagesList = new List<Language>();
            PeopleList = new List<Person>();
        }

    }
}
