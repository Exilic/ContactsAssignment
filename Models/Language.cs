using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_week4849.Models
{
    public class Language
    {

        public int Id { get; set; }
        public string LanguageName { get; set; }
        public virtual IList<PersonLanguage> PersonLanguages { get; set; }

        public Language() {}

        public Language(string language)
        {
            LanguageName = language;
        }
    }
}
