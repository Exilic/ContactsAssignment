using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mvc_week4849.Models.Database;

namespace mvc_week4849.Models.Data
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Create(string PersonName, string PhoneNumber, City City, Language Language)
        {
            Person person = new Person(PersonName, PhoneNumber, City, Language);
            _peopleDbContext.PersonList.Add(person);
            _peopleDbContext.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            _peopleDbContext.PersonList.Remove(person);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Person> Read()
        {
            return _peopleDbContext.PersonList
                .Include(p => p.City)
                .Include(p => p.PersonLanguages)
                .ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.PersonList
                .Include(p => p.City)
                .Include(p => p.PersonLanguages)
                .SingleOrDefault(PersonList => PersonList.Id == id);
        }

        public Person Update(Person person)
        {
            foreach (var language in person.PersonLanguages)
            {
                _peopleDbContext.PersonLanguagesList.Update(language);
            }

            _peopleDbContext.PersonList.Update(person);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return person;
            }
            else
            {
                return null;
            }
        }
    }
}
