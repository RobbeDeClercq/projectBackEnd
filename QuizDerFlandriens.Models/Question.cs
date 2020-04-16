using System;
using System.Collections.Generic;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid QuizId { get; set; }

        //Navigatie props
        public Quiz Quiz { get; set; }
    }
}
