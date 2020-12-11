using System;
namespace mvc_week4849.Models
{
    public class Person
    {

        public string PersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public int Id { get; set; }


        public Person () {}

        public Person(string personName, string phoneNumber, string city)
        {
            PersonName = personName;
            PhoneNumber = phoneNumber;
            City = city;
        }

        public Person(int id, string personName, string phoneNumber, string city) : this(personName, phoneNumber, city)
        {
            Id = id;
        }


    }
}
