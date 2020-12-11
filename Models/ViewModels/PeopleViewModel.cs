using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;
using mvc_week4849.Models.Data;
using mvc_week4849.Models.Services;

namespace mvc_week4849.Models.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> PeopleList { get; set; }

        public CreatePersonViewModel CreatePerson { get; set; }

        [Display(Name ="Select posts based on search string: ")]
        public string Search { get; set; }

        public PeopleViewModel()
        {
            PeopleList = new List<Person>();       
        }
    }
}

