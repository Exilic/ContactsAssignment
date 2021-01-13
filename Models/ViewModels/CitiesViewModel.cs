using System;
using System.Collections.Generic;

namespace mvc_week4849.Models.ViewModels
{
    public class CitiesViewModel
    {
        public List<Person> PeopleList { get; set; }
        public List<City> CitiesList { get; set; }
        public List<Country> CountriesList { get; set; }
        public string Search { get; set; }

        public CreateCityViewModel CreateCity { get; set; }

        public CitiesViewModel()
        {
            PeopleList = new List<Person>();
            CitiesList = new List<City>();
        }
    }
}
