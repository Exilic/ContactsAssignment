using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_week4849.Models
{
    public class City
    {
     
        public int Id { get; set; }    

        public string CityName { get; set; }
        public Country Country { get; set; }
        public List<Person> People { get; set; }


        public City() {}

        public City(string city, Country country, List<Person> people)
        {
            CityName = city;
            Country = country;
            People = people;
        }
    }
}
