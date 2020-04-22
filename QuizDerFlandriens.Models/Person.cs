using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Person : IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }
    }
}
