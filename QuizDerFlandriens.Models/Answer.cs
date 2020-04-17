using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Answer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public enum IsCorrect
        {
            [Display(Name = "False")]
            False = 0,
            [Display(Name = "True")]
            True = 1
        }

        public string? Description { get; set; }
        public string? FotoURL { get; set; }
        public IsCorrect Correct { get; set; }
        public Guid QuestionId { get; set; }

        //Navigatie prop
        public Question Question { get; set; }
    }
}
