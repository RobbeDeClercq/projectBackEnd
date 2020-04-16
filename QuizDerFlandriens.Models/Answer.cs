using System;
using System.Collections.Generic;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? FotoURL { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }

        //Navigatie prop
        public Question Question { get; set; }
    }
}
