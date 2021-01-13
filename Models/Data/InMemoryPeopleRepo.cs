using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_week4849.Models.Data
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {

        private static List<Person> peopleList = new List<Person>();
        private static int idCounter = 0;

        public Person Create(string personName, string phoneNumber, City city, Language Language)
        {
            Person person = new Person(++idCounter, personName, phoneNumber, city);
            peopleList.Add(person);
            return person;
        }

        public bool Delete(Person person)
        {
            return peopleList.Remove(person);
        }

        public List<Person> Read()
        {
            return peopleList;
        }

        public Person Read(int id)
        {
            foreach (Person person in peopleList)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }

        public Person Update(Person person)
        {
            Person originalPerson = Read(person.Id);

            if (originalPerson == null)
            {
                return null;
            }

            originalPerson.PersonName = person.PersonName;
            originalPerson.PhoneNumber = person.PhoneNumber;
            originalPerson.City = person.City;

            return originalPerson;
        }
    }
}
