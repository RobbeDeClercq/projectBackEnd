using System;
using System.Collections.Generic;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Result
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid QuizId { get; set; }
        public int Score { get; set; }

        //Nav Props
        public Quiz Quiz { get; set; }
    }
}
