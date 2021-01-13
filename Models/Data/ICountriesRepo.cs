using System;
using System.Collections.Generic;

namespace mvc_week4849.Models.Data
{
    public interface ICountriesRepo
    {
        Country Create(string country, List<City> cities);
        List<Country> Read();
        Country Read(int id);
        Country Update(Country country);
        bool Delete(Country country);
    }
}
