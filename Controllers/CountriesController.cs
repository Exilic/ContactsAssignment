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
    public class CountriesController : Controller
    {

        private ICountriesService _countriesService;
        private ICitiesService _citiesService;

        public CountriesController(ICountriesService countriesService, ICitiesService citiesService)
        {
            _countriesService = countriesService;
            _citiesService = citiesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CountriesViewModel countriesViewModel = _countriesService.All();
            countriesViewModel.CitiesList = _citiesService.All().CitiesList;

            return View(countriesViewModel);
        }


        [HttpPost]
        public IActionResult Filter(CountriesViewModel searchTerm)
        {
            CountriesViewModel countriesViewModel = _countriesService.FindBy(searchTerm);
            countriesViewModel.CitiesList = _citiesService.All().CitiesList;
            return View("Index", countriesViewModel);
        }

        [HttpPost]
        public IActionResult Create(CountriesViewModel countriesViewModel)
        {
            if (ModelState.IsValid)
            {
                _countriesService.Add(countriesViewModel.CreateCountry);

                return RedirectToAction(nameof(Index));
            }
            return View("Index", _countriesService.All());
        }

        public IActionResult Delete(int id)
        {
            if (_countriesService.Remove(id))
            {
                ViewBag.msg = "The post was deleted";
            }
            else
            {
                ViewBag.msg = "Unable to delete the post";
            }
            CountriesViewModel countriesViewModel = _countriesService.All();
            countriesViewModel.CitiesList = _citiesService.All().CitiesList;
            return View("Index", countriesViewModel);
        }
    }
}
