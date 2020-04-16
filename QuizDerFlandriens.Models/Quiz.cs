using System;
using System.Collections.Generic;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public Guid DifficultyId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Guid PersonId { get; set; }

        //Navigatie Props
        public Person Person { get; set; }


    }
}
