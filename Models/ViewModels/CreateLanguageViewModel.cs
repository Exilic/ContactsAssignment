using System;
using System.ComponentModel.DataAnnotations;

namespace mvc_week4849.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
