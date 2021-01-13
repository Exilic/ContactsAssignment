using System;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Models.Services
{
    public interface ICountriesService
    {
        Country Add(CreateCountryViewModel country);
        CountriesViewModel All();
        CountriesViewModel FindBy(CountriesViewModel search);
        Country FindBy(int id);
        Country Edit(int id, Country country);
        bool Remove(int id);
    }
}

