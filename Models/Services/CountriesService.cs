using System;
using System.Collections.Generic;
using mvc_week4849.Models.Data;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Models.Services
{
    public class CountriesService : ICountriesService
    {
        ICountriesRepo _countriesRepo;

        public CountriesService(ICountriesRepo countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }

        public Country Add(CreateCountryViewModel country)
        {
            List<City> citiesList = new List<City>();
            return _countriesRepo.Create(country.CountryName, citiesList);
        }

        public CountriesViewModel All()
        {
            CountriesViewModel countriesViewModel = new CountriesViewModel();

            countriesViewModel.CountriesList = _countriesRepo.Read();

            return countriesViewModel;
        }

        public Country Edit(int id, Country country)
        {
            Country editedCountry = new Country() { Id = id, CountryName = country.CountryName };

            return _countriesRepo.Update(editedCountry);
        }

        public CountriesViewModel FindBy(CountriesViewModel search)
        {
            if (search.Search != null)
            {
                foreach (var item in _countriesRepo.Read())
                {

                    if (item.CountryName.Contains(search.Search))
                    {
                        search.CountriesList.Add(item);
                    }
                }
            }
            else { search.CountriesList = _countriesRepo.Read(); }

            return search;
        }

        public Country FindBy(int id)
        {
            return _countriesRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Country country = _countriesRepo.Read(id);
            if (country == null)
            {
                return false;
            }
            else
            {
                _countriesRepo.Delete(country);
                return true;
            }
        }
    }
}
