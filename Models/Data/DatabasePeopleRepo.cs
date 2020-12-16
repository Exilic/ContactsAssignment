using System;
using System.Collections.Generic;
using System.Linq;
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

        public Person Create(string PersonName, string PhoneNumber, string City)
        {
            Person person = new Person(PersonName, PhoneNumber, City);
            _peopleDbContext.Add(person);
            _peopleDbContext.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {

            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            return _peopleDbContext.PersonList.ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.PersonList.SingleOrDefault(PersonList => PersonList.Id == id);
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
