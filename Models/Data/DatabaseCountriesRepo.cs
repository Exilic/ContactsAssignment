using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mvc_week4849.Models.Database;

namespace mvc_week4849.Models.Data
{
    public class DatabaseCountriesRepo : ICountriesRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabaseCountriesRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Country Create(string Country, List<City> Cities)
        {
            Country country  = new Country(Country, Cities);
            _peopleDbContext.CountriesList.Add(country);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return country;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(Country country)
        {
            _peopleDbContext.CountriesList.Remove(country);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Country> Read()
        {
            return _peopleDbContext.CountriesList
                .Include(c => c.Cities)
                .ToList();
        }

        public Country Read(int id)
        {
            return _peopleDbContext.CountriesList
                .Include(c => c.Cities)
                .SingleOrDefault(CountriesList => CountriesList.Id == id);
        }

        public Country Update(Country country)
        {
            _peopleDbContext.CountriesList.Update(country);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return country;
            }
            else
            {
                return null;
            }
        }
    }
}
