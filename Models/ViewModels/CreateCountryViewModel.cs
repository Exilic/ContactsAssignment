using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_week4849.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        public string CountryName { get; set; }        
    }
}
