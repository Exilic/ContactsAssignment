using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace mvc_week4849.Models
{
    public class CreatePersonViewModel
    {

        [Required]
        public string PersonName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int CityId { get; set; }

        public int LanguageId { get; set; }

    }
}
