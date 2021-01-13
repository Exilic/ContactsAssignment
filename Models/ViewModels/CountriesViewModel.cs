using System;
using System.Collections.Generic;

namespace mvc_week4849.Models.ViewModels
{
    public class CountriesViewModel
    {
        public List<Country> CountriesList { get; set; }
        public List<City> CitiesList { get; set; }
        public string Search { get; set; }

        public CreateCountryViewModel CreateCountry { get; set; }

        public CountriesViewModel()
        {
            CountriesList = new List<Country>();
            CitiesList = new List<City>();
        }
    }
}
