using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace QuizDerFlandriens.Models
{
    public class Difficulty
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The Difficulty needs a description")]
        [Display(Name = "Difficulty description")]
        public string Description { get; set; }
    }
}
