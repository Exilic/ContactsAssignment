using System;
using System.Collections.Generic;
using mvc_week4849.Models.Data;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Models.Services
{
    public class CitiesService : ICitiesService
    {
        ICitiesRepo _citiesRepo;
        ICountriesRepo _countriesRepo;

        public CitiesService(ICitiesRepo citiesRepo, ICountriesRepo countriesRepo)
        {
            _citiesRepo = citiesRepo;
            _countriesRepo = countriesRepo;

        }

        public City Add(CreateCityViewModel city)
        {
            Country country = _countriesRepo.Read(city.CountryId);
            List<Person> peopleList = new List<Person>();
            return _citiesRepo.Create(city.CityName, country, peopleList);
        }

        public CitiesViewModel All()
        {
            CitiesViewModel citiesViewModel = new CitiesViewModel();

            citiesViewModel.CitiesList = _citiesRepo.Read();

            return citiesViewModel;

        }

        public City Edit(int id, City city)
        {
            City editedCity = new City() { Id = id, CityName = city.CityName, Country = city.Country };

            return _citiesRepo.Update(editedCity);
        }

        public CitiesViewModel FindBy(CitiesViewModel search)
        {
            if (search.Search != null)
            {
                foreach (var item in _citiesRepo.Read())
                {
                    if (item.CityName.Contains(search.Search))
                    {
                        search.CitiesList.Add(item);
                    }
                }
            }
            else { search.CitiesList = _citiesRepo.Read(); }

            return search;
        }

        public City FindBy(int id)
        {
            return _citiesRepo.Read(id);
        }

        public bool Remove(int id)
        {
            City city = _citiesRepo.Read(id);
            if (city == null)
            {
                return false;
            }
            else
            {
                _citiesRepo.Delete(city);
                return true;
            }
        }
    }
}
