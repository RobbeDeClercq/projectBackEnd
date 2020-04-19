using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizDerFlandriens.Models;
using QuizDerFlandriens.Models.Repositories;

namespace QuizDerFlandriens.Controllers
{
    public class QuizController : Controller
    {
        private IQuizRepo quizRepo;

        public QuizController(IQuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        public async Task<IActionResult> Quizzes()
        {
            IEnumerable<Quiz> quizzes = null;
            quizzes = await quizRepo.GetAllQuizzesAsync();
            foreach (Quiz quiz in quizzes)
            {
                foreach (Question question in quiz.Questions)
                {
                    IEnumerable<Answer> answersEnum = await quizRepo.GetAllAnswersByQuestionId(question.Id);
                    List<Answer> answers = answersEnum.ToList();
                    question.Answers = answers;
                }
            }
            return View(quizzes);
        }
    }
}