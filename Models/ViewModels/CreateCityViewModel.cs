using System;
using System.ComponentModel.DataAnnotations;

namespace mvc_week4849.Models.ViewModels
{
    public class CreateCityViewModel
    {

        [Required]
        public string CityName { get; set; }
       
        public int CountryId { get; set; }
    }
}
