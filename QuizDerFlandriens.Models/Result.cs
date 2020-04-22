using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Result
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuizId { get; set; }
        public int Score { get; set; }

        //Nav Props
        public Quiz Quiz { get; set; }
        public Person Person { get; set; }
    }
}
