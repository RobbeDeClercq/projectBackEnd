using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizDerFlandriens.API.Models
{
    public class Answer_DTO
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public enum IsCorrect
        { 
            False = 0,
            True = 1
        }

        public string? Description { get; set; } = "No text answer";

        public string? FotoURL { get; set; } = "No Image";

        [Required]
        public IsCorrect Correct { get; set; }
    }
}
