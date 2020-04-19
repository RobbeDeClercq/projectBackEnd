using Microsoft.AspNetCore.Http;
using QuizDerFlandriens.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizDerFlandriens.ViewModels
{
    public class AnswerEditViewModel
    {
        public Guid Id { get; set; }
        public enum IsCorrect
        {
            [Display(Name = "False")]
            False = 0,
            [Display(Name = "True")]
            True = 1
        }

        public string? Description { get; set; }
        public IFormFile? Foto { get; set; }
        public string? FotoURL { get; set; }
        public IsCorrect Correct { get; set; }
        public Guid QuestionId { get; set; }

        //Navigatie prop
        public Question Question { get; set; }
    }
}
