using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizDerFlandriens.API.Models
{
    public class Result_DTO
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Score { get; set; }
    }
}
