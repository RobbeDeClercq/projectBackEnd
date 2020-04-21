using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizDerFlandriens.Models;
using QuizDerFlandriens.Models.Repositories;

namespace QuizDerFlandriens.Controllers
{
    public class QuizController : Controller
    {
        private IQuizRepo quizRepo;
        private UserManager<Person> userManager;

        public QuizController(IQuizRepo quizRepo, UserManager<Person> userManager)
        {
            this.quizRepo = quizRepo;
            this.userManager = userManager;
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
        public IActionResult PlayQuiz(Guid id)
        {
            //IEnumerable<Question> questions = await quizRepo.GetAllQuestionsByQuizId(id);
            return RedirectToAction(nameof(ShowQuestion), new { quizId = id, currentQuestion = 0, score = 0 });
        }

        public async Task<IActionResult> ShowQuestion(Guid quizId, int currentQuestion, int score)
        {
            IEnumerable<Question> questions = await quizRepo.GetAllQuestionsByQuizId(quizId);
            List<Question> questionsList = questions.ToList();
            float progressPercentage = (float.Parse(currentQuestion.ToString())/float.Parse(questionsList.Count().ToString()))*100;
            ViewData["ProgressPercentage"] = progressPercentage;
            ViewData["PotentialScore"] = currentQuestion;
            ViewData["Score"] = score;
            if(currentQuestion == questionsList.Count())
            {
                return RedirectToAction(nameof(EndQuiz), new { score = score, maxScore = currentQuestion, quizId = quizId });
            }
            Question question = await quizRepo.GetQuestionForIdAsync(questionsList[currentQuestion].Id);
            return View(question);
        }

        public IActionResult CheckAnswer(bool isCorrect, Guid quizId, int currentQuestion, int score)
        {
            if (isCorrect)
            {
                score++;
            }
            currentQuestion++;
            return RedirectToAction(nameof(ShowQuestion), new { quizId = quizId, currentQuestion = currentQuestion, score = score });
        }

        public async Task<IActionResult> EndQuiz(int score, int maxScore, Guid QuizId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Quiz quiz = await quizRepo.GetQuizForIdAsync(QuizId);
            Result result = new Result()
            {
                Id = Guid.NewGuid(),
                Score = score,
                QuizId = QuizId,
                Quiz = quiz
            };
            string personId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Person person = await userManager.FindByIdAsync(personId);
            result.Person = person;
            ViewData["MaxScore"] = maxScore;
            ViewData["PersonName"] = person.Name;
            ViewData["QuizName"] = quiz.Subject;
            var created = await quizRepo.AddResult(result);
            if (created == null)
            {
                throw new Exception("Invalid Entry");
            }
            return View(result);
        }


    }
}