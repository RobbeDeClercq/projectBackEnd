using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace QuizDerFlandriens.Models
{
    public class Question
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "You need a question")]
        [Display(Name = "Question")]
        public string Description { get; set; }

        [Required]
        public Guid QuizId { get; set; }

        //Navigatie props
        public Quiz Quiz { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
