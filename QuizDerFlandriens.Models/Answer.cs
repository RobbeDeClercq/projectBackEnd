using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace QuizDerFlandriens.Models
{
    public class Answer
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

        public enum IsCorrect
        {
            [Display(Name = "False")]
            False = 0,
            [Display(Name = "True")]
            True = 1
        }

        [Display(Name = "Answer")]
        public string? Description { get; set; }

        [Display(Name = "Foto file name")]
        public string? FotoURL { get; set; }

        [Required]
        public IsCorrect Correct { get; set; }

        [Required]
        public Guid QuestionId { get; set; }

        //Navigatie prop
        public Question Question { get; set; }
    }
}
