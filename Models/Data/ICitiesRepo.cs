using System;
using System.Collections.Generic;

namespace mvc_week4849.Models.Data
{
    public interface ICitiesRepo
    {
        City Create(string City, Country Country, List<Person> People);
        List<City> Read();
        City Read(int id);
        City Update(City city);
        bool Delete(City city);
    }
}
