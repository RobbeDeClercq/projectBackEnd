using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Person : IdentityUser
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
