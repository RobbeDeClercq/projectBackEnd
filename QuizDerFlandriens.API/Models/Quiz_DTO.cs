using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizDerFlandriens.API.Models
{
    public class Quiz_DTO
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        //Navigatie Props
        public Difficulty_DTO Difficulty { get; set; }
        public List<Result_DTO> Results { get; set; }
        public List<Question_DTO> Questions { get; set; }
    }
}
