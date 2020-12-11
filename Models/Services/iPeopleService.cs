using System;
using System.Collections.Generic;
using mvc_week4849.Models.ViewModels;

namespace mvc_week4849.Models.Services
{
    
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel search);
        Person FindBy(int id);
        Person Edit(int id, Person person);
        bool Remove(int id);
    }   
}
