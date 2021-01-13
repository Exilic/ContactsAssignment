using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_week4849.Models;
using mvc_week4849.Models.Services;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Controllers
{
    public class CitiesController : Controller
    {
        private ICountriesService _countriesService;
        private ICitiesService _citiesService;
        private IPeopleService _peopleService;


        public CitiesController(ICountriesService countriesService, ICitiesService citiesService, IPeopleService peopleService)
        {
            _countriesService = countriesService;
            _citiesService = citiesService;
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CitiesViewModel citiesViewModel = _citiesService.All();
            citiesViewModel.PeopleList = _peopleService.All().PeopleList;
            citiesViewModel.CountriesList = _countriesService.All().CountriesList;

            return View(citiesViewModel);
        }

        [HttpPost]
        public IActionResult Filter(CitiesViewModel searchTerm)
        {
            CitiesViewModel citiesViewModel = _citiesService.FindBy(searchTerm);
            citiesViewModel.CountriesList = _countriesService.All().CountriesList;
            citiesViewModel.PeopleList = _peopleService.All().PeopleList;

            return View("Index", citiesViewModel);
        }

        [HttpPost]
        public IActionResult Create(CitiesViewModel citiesViewModel)
        {
            if (ModelState.IsValid)
            {
                _citiesService.Add(citiesViewModel.CreateCity);

                return RedirectToAction(nameof(Index));
            }


            return View("Index", _citiesService.All());
        }

        public IActionResult Delete(int id)
        {
            if (_citiesService.Remove(id))
            {
                ViewBag.msg = "The post was deleted";
            }
            else
            {
                ViewBag.msg = "Unable to delete the post";
            }
            CitiesViewModel citiesViewModel = _citiesService.All();
            citiesViewModel.CountriesList = _countriesService.All().CountriesList;
            return View("Index", citiesViewModel);
        }
    }
}
