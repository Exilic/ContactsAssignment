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
    public class PeopleController : Controller
    {

        private IPeopleService _peopleService = new PeopleService();


        [HttpGet]
        public IActionResult Index()
        {
           return View(_peopleService.All());
        }

     
        [HttpPost]
        public IActionResult Filter(PeopleViewModel peopleViewModel)
        {
           return View("Index", _peopleService.FindBy(peopleViewModel));
        }

 
        [HttpPost]
        public IActionResult Create(PeopleViewModel peopleViewModel)
        {           
           if (ModelState.IsValid)
           {
               _peopleService.Add(peopleViewModel.CreatePerson);

               return RedirectToAction(nameof(Index));
           }

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

            return View("Index", _peopleService.All());
       }


      
       [HttpGet]
       public IActionResult Partialview()
       {
          return View(_peopleService.All());
       }


       [HttpPost]
       public IActionResult CreatePartial(PeopleViewModel peopleViewModel)
          {
          if (ModelState.IsValid)
          {
              _peopleService.Add(peopleViewModel.CreatePerson);

              return RedirectToAction(nameof(Partialview));
          }
          return View("Partialview", peopleViewModel);
       }

       
       [HttpPost]
       public IActionResult FilterPartial(PeopleViewModel peopleViewModel)
       {
          return View("Partialview", _peopleService.FindBy(peopleViewModel));
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
                   
            return View("Partialview", _peopleService.All());
       }
       

       [HttpGet]
       public IActionResult Ajax()
       {
          return View(_peopleService.All());
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
            Person personToEdit = _peopleService.FindBy(id);

            return PartialView("_EditPeopleAjaxPartialView", personToEdit);
        }

        [HttpPost]
        public IActionResult AjaxEditPost(Person person)
        {
            CreatePersonViewModel personToEdit = new CreatePersonViewModel()
            {
                PersonName = person.PersonName,
                PhoneNumber = person.PhoneNumber,
                City = person.City
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
