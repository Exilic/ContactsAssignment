using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_week4849.Models.Services;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Controllers
{
    public class LanguagesController : Controller
    {
        private ILanguagesService _languagesService;
        private ICitiesService _citiesService;
        private IPeopleService _peopleService;


        public LanguagesController(ILanguagesService languagesService, ICitiesService citiesService, IPeopleService peopleService)
        {
            _languagesService = languagesService;
            _citiesService = citiesService;
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LanguagesViewModel languagesViewModel = _languagesService.All();
            languagesViewModel.PeopleList = _peopleService.All().PeopleList;

            return View(languagesViewModel);
        }


        [HttpPost]
        public IActionResult Filter(LanguagesViewModel searchTerm)
        {
            return View("Index", _languagesService.FindBy(searchTerm));
        }



        [HttpPost]
        public IActionResult Create(LanguagesViewModel languagesViewModel)
        {
            if (ModelState.IsValid)
            {
                _languagesService.Add(languagesViewModel.CreateLanguage);

                return RedirectToAction(nameof(Index));
            }
            return View("Index", _languagesService.All());
        }

        public IActionResult Delete(int id)
        {
            if (_languagesService.Remove(id))
            {
                ViewBag.msg = "The post was deleted";
            }
            else
            {
                ViewBag.msg = "Unable to delete the post";
            }
            LanguagesViewModel languagesViewModel = _languagesService.All();
            languagesViewModel.PeopleList = _peopleService.All().PeopleList;
            return View("Index", languagesViewModel);
        }
    }
}