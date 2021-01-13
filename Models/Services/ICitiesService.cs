using System;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Models.Services
{
    public interface ICitiesService
    {
        City Add(CreateCityViewModel city);
        CitiesViewModel All();
        CitiesViewModel FindBy(CitiesViewModel search);
        City FindBy(int id);
        City Edit(int id, City city);
        bool Remove(int id);
    }
}
