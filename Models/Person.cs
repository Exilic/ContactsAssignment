using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_week4849.Models
{
    public class Person
    {

        public string PersonName { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public virtual IList<PersonLanguage> PersonLanguages { get; set; }

        public int Id { get; set; }


        public Person () {}

        public Person(string personName, string phoneNumber, City city)
        {
            PersonName = personName;
            PhoneNumber = phoneNumber;
            City = city;
        }

        public Person(string personName, string phoneNumber, City city, Language language) : this(personName, phoneNumber, city)
        {
            PersonLanguages = (IList<PersonLanguage>)language;
        }

        public Person(int id, string personName, string phoneNumber, City city) : this(personName, phoneNumber, city)
        {
            Id = id;
        }
    }
}
