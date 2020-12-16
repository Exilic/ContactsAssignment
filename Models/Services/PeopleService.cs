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

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel createPersonViewModel)
        {
            return _peopleRepo.Create(createPersonViewModel.PersonName, createPersonViewModel.PhoneNumber, createPersonViewModel.City);
        }

        
        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.PeopleList = _peopleRepo.Read();

            return peopleViewModel;
        }
        

        public Person Edit(int id, Person person)
        {
            Person editedPerson = new Person() { Id = id, PersonName = person.PersonName, PhoneNumber = person.PhoneNumber, City = person.City };
       
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
                    if (item.PersonName.Contains(search.Search) || item.City.Contains(search.Search))
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