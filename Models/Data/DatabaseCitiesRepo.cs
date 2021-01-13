using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mvc_week4849.Models.Database;

namespace mvc_week4849.Models.Data
{
    public class DatabaseCitiesRepo : ICitiesRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabaseCitiesRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public City Create(string City, Country Country, List<Person> People)
        {
            City city = new City(City, Country, People);
            _peopleDbContext.CitiesList.Add(city);
            if (_peopleDbContext.SaveChanges() > 0)
            {
                return city;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(City city)
        {
            _peopleDbContext.CitiesList.Remove(city);
            if (_peopleDbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<City> Read()
        {
            return _peopleDbContext.CitiesList
                .Include(city => city.People)
                .Include(city => city.Country)
                .ToList();
        }

        public City Read(int id)
        {
            return _peopleDbContext.CitiesList
                .Include(city => city.People)
                .Include(city => city.Country)
                .SingleOrDefault(citiesList => citiesList.Id == id);
        }

        public City Update(City city)
        {
            _peopleDbContext.CitiesList.Update(city);
            if (_peopleDbContext.SaveChanges() > 0)
            {
                return city;
            }
            else
            {
                return null;
            }
        }
    }
}
