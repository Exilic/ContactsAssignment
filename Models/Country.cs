using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_week4849.Models
{
    public class Country
    {

        public int Id { get; set; }

        public string CountryName { get; set; }
        public List<City> Cities { get; set; }

        public Country() {}

        public Country(string country, List<City> cities)
        {
            CountryName = country;
            Cities = cities;
        }
    }
}
