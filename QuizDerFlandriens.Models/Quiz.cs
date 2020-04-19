using System;
using System.Collections.Generic;
using System.Text;

namespace QuizDerFlandriens.Models
{
    public class Quiz
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DifficultyId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        //Navigatie Props
        public Person Person { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<Result> Results { get; set; }
        public List<Question> Questions { get; set; }
    }
}
