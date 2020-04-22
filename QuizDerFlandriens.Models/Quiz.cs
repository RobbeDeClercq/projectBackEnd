using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace QuizDerFlandriens.Models
{
    public class Quiz
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid DifficultyId { get; set; }

        [Required(ErrorMessage = "The Name of the quiz is required")]
        [Display(Name = "Quiz Name")]
        public string Subject { get; set; }

        [MinLength(0)]
        [MaxLength(1024)]
        [Required(ErrorMessage = "The quiz needs a description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Navigatie Props
        public Person Person { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<Result> Results { get; set; }
        public List<Question> Questions { get; set; }
    }
}
