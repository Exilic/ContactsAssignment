using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc_week4849.Models;
using mvc_week4849.Models.Services;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService _peopleService;
        private ICitiesService _citiesService;
        private ILanguagesService _languagesService;

        public PeopleController(IPeopleService peopleService, ICitiesService citiesService, ILanguagesService languagesService)
        {
            _peopleService = peopleService;
            _citiesService = citiesService;
            _languagesService = languagesService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            PeopleViewModel peopleViewModel = _peopleService.All();
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View(peopleViewModel);
        }
     
        [HttpPost]
        public IActionResult Filter(PeopleViewModel filtered)
        {
            PeopleViewModel peopleViewModel = _peopleService.FindBy(filtered);
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View("Index", peopleViewModel);
        }
 
        [HttpPost]
        public IActionResult Create(PeopleViewModel newPerson)
        {           
           if (ModelState.IsValid)
           {
               _peopleService.Add(newPerson.CreatePerson);

               return RedirectToAction(nameof(Index));
           }

            PeopleViewModel peopleViewModel = _peopleService.All();
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View("Index", peopleViewModel); 
        }
     
       public IActionResult Delete(int id)
       {
            if (_peopleService.Remove(id))
            {
                ViewBag.msg = "The post was deleted";
            }
            else
            {
                ViewBag.msg = "Unable to delete the post";
            }

            PeopleViewModel peopleViewModel = _peopleService.All();
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View("Index", peopleViewModel);
       }
      
       [HttpGet]
       public IActionResult Partialview()
       {
            PeopleViewModel peopleViewModel = _peopleService.All();
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View(peopleViewModel);
        }

       [HttpPost]
       public IActionResult CreatePartial(PeopleViewModel newPerson)
          {
          if (ModelState.IsValid)
          {
              _peopleService.Add(newPerson.CreatePerson);

              return RedirectToAction(nameof(Partialview));
          }

            PeopleViewModel peopleViewModel = _peopleService.All();
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View("Partialview", peopleViewModel);
       }
      
       [HttpPost]
       public IActionResult FilterPartial(PeopleViewModel filtered)
       {
            PeopleViewModel peopleViewModel = _peopleService.FindBy(filtered);
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View("Partialview", peopleViewModel);
       }
       
       public IActionResult DeletePartial(int id)
       {
            if(_peopleService.Remove(id))
            {
                ViewBag.msg = "The post was deleted";
            }
            else
            {
                ViewBag.msg = "Unable to delete the post";
            }

            PeopleViewModel peopleViewModel = _peopleService.All();
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View("Partialview", peopleViewModel);
        }
       
       [HttpGet]
       public IActionResult Ajax()
       {    
            PeopleViewModel peopleViewModel = _peopleService.All();
            peopleViewModel.CitiesList = _citiesService.All().CitiesList;
            peopleViewModel.LanguagesList = _languagesService.All().LanguagesList;

            return View(peopleViewModel);          
       }

       [HttpGet]
       public IActionResult CreateForm()
       {
          return PartialView("_CreatePeopleAjaxPartialView");
       }

       [HttpPost]
       public IActionResult FilterAjax(PeopleViewModel peopleViewModel)
       {
           return View("Ajax", _peopleService.FindBy(peopleViewModel));
       }
                  
       [HttpPost]
       public IActionResult AjaxDeletePartial(int id)
       {
           if (_peopleService.Remove(id))
           {
               return Ok("The post was deleted");
           }
           else
           {
               return NotFound("Unable to delete the post");
           }        
       }
       
       [HttpGet]
       public IActionResult AjaxEditPost(int id)
       {
            PeopleViewModel peopleViewModel = new PeopleViewModel()
            {
                EditedPerson = _peopleService.FindBy(id),
                CitiesList = _citiesService.All().CitiesList
            };        
           
           return PartialView("_EditPeopleAjaxPartialView", peopleViewModel);
       }

       [HttpPost]
       public IActionResult AjaxEditPost(Person person)
       {
           CreatePersonViewModel personToEdit = new CreatePersonViewModel()

           {
               PersonName = person.PersonName,
               PhoneNumber = person.PhoneNumber,
               CityId = person.City.Id
           };
           if (TryValidateModel(personToEdit))
           {              
               return PartialView("_PeopleAjaxStrippedPartialView", _peopleService.Edit(person.Id, person));
           }
           else
           {
               return PartialView("_PeopleAjaxStrippedPartialView", _peopleService.FindBy(person.Id));
           }
       }
       
       [HttpPost]
       public IActionResult CreateAjax(CreatePersonViewModel createPersonViewModel)
       {
           if (ModelState.IsValid)
           {
               Person person = _peopleService.Add(createPersonViewModel);

               return PartialView("_PeopleAjaxPartialView", person);
           }
           else
           {
               return PartialView("_CreatePeopleAjaxPartialView", createPersonViewModel);
           }
       }     
    }
}
