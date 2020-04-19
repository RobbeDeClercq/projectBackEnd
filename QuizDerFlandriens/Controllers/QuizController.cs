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
        public async Task<IActionResult> PlayQuiz(Guid id)
        {
            IEnumerable<Question> questions = await quizRepo.GetAllQuestionsByQuizId(id);
            return RedirectToAction(nameof(ShowQuestion), new { quizId = id, currentQuestion = 0, score = 0 });
        }

        public async Task<IActionResult> ShowQuestion(Guid quizId, int currentQuestion, int score)
        {
            IEnumerable<Question> questions = await quizRepo.GetAllQuestionsByQuizId(quizId);
            List<Question> questionsList = questions.ToList();
            ViewData["PotentialScore"] = currentQuestion;
            ViewData["Score"] = score;
            if(currentQuestion == questionsList.Count())
            {
                return RedirectToAction(nameof(EndQuiz));
            }
            Question question = await quizRepo.GetQuestionForIdAsync(questionsList[currentQuestion].Id);
            return View(question);
        }

        public async Task<IActionResult> CheckAnswer(bool isCorrect, Guid quizId, int currentQuestion, int score)
        {
            if (isCorrect)
            {
                score++;
            }
            currentQuestion++;
            return RedirectToAction(nameof(ShowQuestion), new { quizId = quizId, currentQuestion = currentQuestion, score = score });
        }

        private async Task<IActionResult> EndQuiz()
        {
            return View();
        }


    }
}