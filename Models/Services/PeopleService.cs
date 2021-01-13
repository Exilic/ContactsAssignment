using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc_week4849.Models.Data;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Models.Services
{
    public class PeopleService : IPeopleService
    {

        IPeopleRepo _peopleRepo;
        ICitiesRepo _citiesRepo;
        ILanguagesRepo _languagesRepo;

        public PeopleService(IPeopleRepo peopleRepo, ICitiesRepo citiesRepo, ILanguagesRepo languagesRepo)
        {
            _peopleRepo = peopleRepo;
            _citiesRepo = citiesRepo;
            _languagesRepo = languagesRepo;
        }

        public Person Add(CreatePersonViewModel createPersonViewModel)
        {
            City city = _citiesRepo.Read(createPersonViewModel.CityId);
            Language language = _languagesRepo.Read(createPersonViewModel.LanguageId);
            return _peopleRepo.Create(createPersonViewModel.PersonName, createPersonViewModel.PhoneNumber, city, language);
        }

        
        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.PeopleList = _peopleRepo.Read();

            return peopleViewModel;
        }
        

        public Person Edit(int id, Person person)
        {
            Person editedPerson = new Person() { Id = id, PersonName = person.PersonName, PhoneNumber = person.PhoneNumber, City = person.City, PersonLanguages = person.PersonLanguages};
       
            return _peopleRepo.Update(editedPerson);
        }


        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }

        
        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            if (search.Search != null)
            {
                foreach (var item in _peopleRepo.Read())
                {
                    if (item.PersonName.Contains(search.Search)
                        || item.PhoneNumber.Contains(search.Search)
                        || item.City.CityName.Contains(search.Search))
                    //if (item.PersonName.Contains(search.Search))
                    {
                        search.PeopleList.Add(item);
                    }
                } 
            } else { search.PeopleList = _peopleRepo.Read(); }

            return search;
        }
        

        public bool Remove(int id)
        {
            Person person = _peopleRepo.Read(id);
            if (person == null)
            {
                return false;
            }
            else
            {
                _peopleRepo.Delete(person);
                return true;
            }
        }
    }
}