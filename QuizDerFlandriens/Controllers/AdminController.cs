using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizDerFlandriens.Models;
using QuizDerFlandriens.Models.Repositories;

namespace QuizDerFlandriens.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IQuizRepo quizRepo;
        private UserManager<Person> userManager;

        public AdminController(IQuizRepo quizRepo, UserManager<Person> userManager)
        {
            this.quizRepo = quizRepo;
            this.userManager = userManager;
        }

        //Quizzes
        public async Task<IActionResult> Quizzes()
        {
            IEnumerable<Quiz> quizzes = null;
            quizzes = await quizRepo.GetAllQuizzesAsync();
            return View(quizzes);
        }
        public async Task<IActionResult> CreateQuiz()
        {
            IEnumerable<Difficulty> difficulties = null;
            difficulties = await quizRepo.GetAllDifficultiesAsync();
            ViewData["Difficulties"] = difficulties;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateQuiz(IFormCollection collection, Quiz quiz)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                Person person = await quizRepo.GetPersonForIdAsync(userManager.GetUserId(User));
                quiz.Person = person;
                var created = await quizRepo.AddQuiz(quiz);
                if (created == null)
                {
                    throw new Exception("Invalid Entry");
                }

                return RedirectToAction(nameof(Quizzes));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create is giving an error: " + ex.Message);
                return View();
            }
        }
        public async Task<IActionResult> EditQuiz(Guid id)
        {
            Quiz quiz = null;
            quiz = await quizRepo.GetQuizForIdAsync(id);
            ViewData["DifficultyId"] = quiz.DifficultyId;
            IEnumerable<Difficulty> difficulties = null;
            difficulties = await quizRepo.GetAllDifficultiesAsync();
            ViewData["Difficulties"] = difficulties;
            return View(quiz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuiz(Guid id, IFormCollection collection, Quiz quiz)
        {
            try
            {
                // TODO: Add update logic here
                var result = await quizRepo.UpdateQuiz(quiz);
                if (result == null)
                {
                    throw new Exception("Invalid Entry");
                }
                return RedirectToAction(nameof(Quizzes));
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            Quiz quiz = null;
            quiz = await quizRepo.GetQuizForIdAsync(id);
            return View(quiz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQuiz(Guid id, IFormCollection collection)
        {
            try
            {
                await quizRepo.DeleteQuiz(id);
                return RedirectToAction(nameof(Quizzes));
            }
            catch
            {
                return View();
            }
        }

        //Questions
        public async Task<IActionResult> QuizQuestions(Guid id)
        {
            ViewData["QuizId"] = id;
            IEnumerable<Question> questions = null;
            questions = await quizRepo.GetAllQuestionsByQuizId(id);
            return View(questions);
        }
        public ActionResult CreateQuestion(Guid id)
        {
            ViewData["QuizId"] = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestion(Guid id, IFormCollection collection, Question question)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                question.Id = Guid.NewGuid();
                question.QuizId = id;
                var created = await quizRepo.AddQuestion(question);
                if (created == null)
                {
                    throw new Exception("Invalid Entry");
                }

                return RedirectToAction(nameof(CreateAnswer), new { id = question.Id, QuizId = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create is giving an error: " + ex.Message);
                return View();
            }
        }
        public async Task<IActionResult> EditQuestion(Guid id)
        {
            Question question = await quizRepo.GetQuestionForIdAsync(id);
            ViewData["QuizId"] = question.QuizId;
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuestion(Guid id, IFormCollection collection, Question question, Guid QuizId)
        {
            try
            {
                // TODO: Add update logic here
                Quiz quiz = await quizRepo.GetQuizForIdAsync(QuizId);
                question.Quiz = quiz;
                var result = await quizRepo.UpdateQuestion(question);
                if (result == null)
                {
                    throw new Exception("Invalid Entry");
                }
                return RedirectToAction(nameof(QuizQuestions), new { id = QuizId });
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            Question question = null;
            question = await quizRepo.GetQuestionForIdAsync(id);
            ViewData["QuizId"] = question.QuizId;
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQuestion(Guid id, IFormCollection collection, Guid QuizId)
        {
            try
            {
                await quizRepo.DeleteQuestion(id);
                return RedirectToAction(nameof(QuizQuestions), new { id = QuizId });
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                return View();
            }
        }

        //Answers
        public async Task<IActionResult> QuestionAnswers(Guid id, Guid QuizId)
        {
            ViewData["QuestionId"] = id;
            ViewData["QuizId"] = QuizId;
            IEnumerable<Answer> answers = await quizRepo.GetAllAnswersByQuestionId(id);
            return View(answers);
        }
        public async Task<IActionResult> CreateAnswer(Guid id, Guid QuizId)
        {
            IEnumerable<Answer> answers = await quizRepo.GetAllAnswersByQuestionId(id);
            var answerCount = answers.Count();
            ViewData["answersCount"] = answerCount;
            ViewData["QuestionId"] = id;
            ViewData["QuizId"] = QuizId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnswer(Guid id, IFormCollection collection, Answer answer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                answer.Id = Guid.NewGuid();
                answer.QuestionId = id;
                Question question = await quizRepo.GetQuestionForIdAsync(id);
                answer.Question = question;
                var created = await quizRepo.AddAnswer(answer);
                if (created == null)
                {
                    throw new Exception("Invalid Entry");
                }
                return RedirectToAction(nameof(CreateAnswer), new { id = id, QuizId = question.QuizId });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create is giving an error: " + ex.Message);
                return View();
            }
        }
        public async Task<IActionResult> EditAnswer(Guid id, Guid QuizId)
        {
            Answer answer = await quizRepo.GetAnswerForIdAsync(id);
            ViewData["QuestionId"] = answer.QuestionId;
            ViewData["IsCorrect"] = answer.Correct;
            ViewData["QuizId"] = QuizId;
            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnswer(Guid id, IFormCollection collection, Answer answer, Guid QuizId, Guid QuestionId)
        {
            try
            {
                // TODO: Add update logic here
                Question question = await quizRepo.GetQuestionForIdAsync(QuestionId);
                answer.Question = question;
                var result = await quizRepo.UpdateAnswer(answer);
                if (result == null)
                {
                    throw new Exception("Invalid Entry");
                }
                return RedirectToAction(nameof(QuestionAnswers), new { id = QuestionId, QuizId = QuizId });
            }
            catch
            {
                return View();
            }
        }

    }
}