using System;
namespace mvc_week4849.Models
{
    public class PersonLanguage
    {
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public Person Person { get; set; }
        public Language Language { get; set; }
    }
}
