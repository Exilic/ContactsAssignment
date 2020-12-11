using System;
using System.Collections.Generic;

namespace mvc_week4849.Models.Data
{
    
    public interface IPeopleRepo
    {
        Person Create(string PersonName, string PhoneNumber, string City);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        bool Delete(Person person);
    }
    
}
