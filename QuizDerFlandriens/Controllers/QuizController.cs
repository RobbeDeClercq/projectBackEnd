using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class QuizController : Controller
    {
        private IQuizRepo quizRepo;
        private UserManager<Person> userManager;
        public static int score;
        public static int currentQuestion = 0;
        public static Guid QuizId;
        public static List<Question> wrongQuestions = new List<Question>();

        public QuizController(IQuizRepo quizRepo, UserManager<Person> userManager)
        {
            this.quizRepo = quizRepo;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Quizzes()
        {
            QuizController.score = 0;
            QuizController.currentQuestion = 0;
            QuizController.wrongQuestions = new List<Question>();

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
        public async Task<IActionResult> QuizScores(Guid id, string quizName)
        {
            var results = await quizRepo.GetAllResultsByQuizId(id);
            ViewData["QuizName"] = quizName;
            return View(results);
        }
        public IActionResult PlayQuiz(Guid id)
        {
            QuizController.QuizId = id;
            return RedirectToAction(nameof(ShowQuestion));
        }
        public async Task<IActionResult> ShowQuestion()
        {
            IEnumerable<Question> questions = await quizRepo.GetAllQuestionsByQuizId(QuizController.QuizId);
            
            List<Question> questionsList = questions.ToList();
            List<Question> wrongQuestions = new List<Question>();
            //Antwoorden checken of question inorde is
            foreach (Question q in questionsList)
            {
                IEnumerable<Answer> answers = await quizRepo.GetAllAnswersByQuestionId(q.Id);

                bool error = false;
                if (answers.Count() < 2)
                {
                    error = true;
                }
                else
                {
                    int countTrues = 0;
                    bool onlyDiscriptions = true;
                    bool onlyPhotos = true;
                    foreach (Answer answer in answers)
                    {
                        if (answer.Correct.ToString() == "True")
                        {
                            countTrues = countTrues + 1;
                        }
                        if (answer.Description == null)
                        {
                            onlyDiscriptions = false;
                        }
                        if (answer.FotoURL == null)
                        {
                            onlyPhotos = false;
                        }
                    }
                    if (!onlyDiscriptions && !onlyPhotos)
                    {
                        error = true;
                    }
                    if (countTrues == 0)
                    {
                        error = true;
                    }
                    else if (countTrues > 1)
                    {
                        error = true;
                    }
                }
                if (error)
                {
                    wrongQuestions.Add(q);
                }
            }

            foreach (Question q in wrongQuestions)
            {
                questionsList.Remove(q);
            }

            float progressPercentage = (float.Parse(QuizController.currentQuestion.ToString())/float.Parse(questionsList.Count().ToString()))*100;
            ViewData["ProgressPercentage"] = progressPercentage;
            ViewData["PotentialScore"] = QuizController.currentQuestion;
            ViewData["Score"] = QuizController.score;
            if(QuizController.currentQuestion == questionsList.Count())
            {
                return RedirectToAction(nameof(EndQuiz));
            }
            Question question = await quizRepo.GetQuestionForIdAsync(questionsList[QuizController.currentQuestion].Id);
            return View(question);
        }
        public async Task<IActionResult> CheckAnswer(bool isCorrect, Guid id)
        {
            if (isCorrect)
            {
                QuizController.score++;
            }
            else
            {
                Question question = await quizRepo.GetQuestionForIdAsync(id);
                QuizController.wrongQuestions.Add(question);
            }
            QuizController.currentQuestion++;
            return RedirectToAction(nameof(ShowQuestion));
        }
        public async Task<IActionResult> EndQuiz()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Quiz quiz = await quizRepo.GetQuizForIdAsync(QuizController.QuizId);
            Result result = new Result()
            {
                Id = Guid.NewGuid(),
                Score = QuizController.score,
                QuizId = QuizController.QuizId,
                Quiz = quiz
            };
            string personId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Person person = await userManager.FindByIdAsync(personId);
            result.Person = person;
            ViewData["MaxScore"] = QuizController.currentQuestion;
            ViewData["PersonName"] = person.Name;
            ViewData["QuizName"] = quiz.Subject;
            ViewData["WrongQuestions"] = QuizController.wrongQuestions;
            var created = await quizRepo.AddResult(result);
            if (created == null)
            {
                throw new Exception("Invalid Entry");
            }
            return View(result);
        }

    }
}