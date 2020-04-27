using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizDerFlandriens.Models;
using QuizDerFlandriens.Models.Repositories;
using QuizDerFlandriens.ViewModels;

namespace QuizDerFlandriens.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IQuizRepo quizRepo;
        private UserManager<Person> userManager;
        private IHostingEnvironment hostingEnvironment;

        public AdminController(IQuizRepo quizRepo, UserManager<Person> userManager, IHostingEnvironment hostingEnvironment)
        {
            this.quizRepo = quizRepo;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        //Quizzes
        public async Task<IActionResult> Quizzes(string? exc)
        {
            if (exc != null)
            {
                ViewData["Exception"] = exc;
            }
            IEnumerable<Quiz> quizzes = null;
            quizzes = await quizRepo.GetAllQuizzesAsync();
            foreach(Quiz quiz in quizzes)
            {
                IEnumerable<Question> questionsEnum = await quizRepo.GetAllQuestionsByQuizId(quiz.Id);
                List<Question> questions = questionsEnum.ToList();
                quiz.Questions = questions;
            }
            return View(quizzes);
        }
        public async Task<IActionResult> CreateQuiz()
        {
            try
            {
                IEnumerable<Difficulty> difficulties = null;
                difficulties = await quizRepo.GetAllDifficultiesAsync();
                ViewData["Difficulties"] = difficulties;
                return View();
            }
            catch (Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
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
                    return RedirectToAction(nameof(Quizzes), new { exc = "Quiz did not create" });
                }

                return RedirectToAction(nameof(Quizzes));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = ex.Message });
            }
        }
        public async Task<IActionResult> EditQuiz(Guid id)
        {
            try
            {
                Quiz quiz = null;
                quiz = await quizRepo.GetQuizForIdAsync(id);
                if(quiz == null || id == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong quiz Id" });
                }
                ViewData["DifficultyId"] = quiz.DifficultyId;
                IEnumerable<Difficulty> difficulties = null;
                difficulties = await quizRepo.GetAllDifficultiesAsync();
                ViewData["Difficulties"] = difficulties;
                return View(quiz);
            }
            catch(Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
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
                    return RedirectToAction(nameof(Quizzes), new { exc = "Update quiz failed..." });
                }
                return RedirectToAction(nameof(Quizzes));
            }
            catch(Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            try
            {
                Quiz quiz = null;
                quiz = await quizRepo.GetQuizForIdAsync(id);
                if (quiz == null || id == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong quiz Id" });
                }
                return View(quiz);
            }
            catch(Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
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
            catch(Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }

        //Results
        public async Task<IActionResult> QuizResults(Guid QuizId, string quizName)
        {
            IEnumerable<Result> results = null;
            results = await quizRepo.GetAllResultsByQuizId(QuizId);
            if(QuizId == Guid.Empty)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
            }
            ViewData["QuizName"] = quizName;
            return View(results);
        }
        public async Task<IActionResult> DeleteResult(Guid id, Guid QuizId, string quizName)
        {
            Result result = null;
            result = await quizRepo.GetResultByIdAsync(id);
            if(result == null || id == Guid.Empty)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = "Wrong ResultId" });
            }
            var obj = await quizRepo.GetQuizForIdAsync(QuizId);
            if (obj == null || QuizId == Guid.Empty)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
            }
            ViewData["QuizId"] = QuizId;
            ViewData["QuizName"] = quizName;
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteResult(Guid id, IFormCollection collection, Guid QuizId, string quizName)
        {
            try
            {
                await quizRepo.DeleteResult(id);
                var obj = await quizRepo.GetQuizForIdAsync(QuizId);
                if (obj == null || QuizId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
                }
                return RedirectToAction(nameof(QuizResults), new { QuizId = QuizId, quizName = quizName });
            }
            catch(Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }

        //Questions
        public async Task<IActionResult> QuizQuestions(Guid id)
        {
            ViewData["QuizId"] = id;
            Quiz quiz = await quizRepo.GetQuizForIdAsync(id);
            if (quiz == null || id == Guid.Empty)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
            }
            ViewData["QuizName"] = quiz.Subject;
            IEnumerable<Question> questions = null;
            questions = await quizRepo.GetAllQuestionsByQuizId(id);
            return View(questions);
        }
        public async Task<IActionResult> CreateQuestion(Guid id)
        {
            ViewData["QuizId"] = id;
            Quiz quiz = await quizRepo.GetQuizForIdAsync(id);
            if (quiz == null || id == Guid.Empty)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
            }
            ViewData["QuizName"] = quiz.Subject;
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
                Quiz quiz = await quizRepo.GetQuizForIdAsync(id);
                if (quiz == null || id == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
                }
                question.Id = Guid.NewGuid();
                question.QuizId = id;
                var created = await quizRepo.AddQuestion(question);
                if (created == null)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Failed To Create Question" });
                }

                return RedirectToAction(nameof(CreateAnswer), new { id = question.Id, QuizId = id, createSingleAnswer = false });
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
            if (question == null || id == Guid.Empty)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuestionId" });
            }
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
                if (quiz == null || QuizId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong quizId..." });
                }
                question.Quiz = quiz;
                var result = await quizRepo.UpdateQuestion(question);
                if (result == null)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Failed To update Question" });
                }
                return RedirectToAction(nameof(QuizQuestions), new { id = QuizId });
            }
            catch(Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            Question question = null;
            question = await quizRepo.GetQuestionForIdAsync(id);
            if (question == null || id == Guid.Empty)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuestionId" });
            }
            ViewData["QuizId"] = question.QuizId;
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQuestion(Guid id, IFormCollection collection, Guid QuizId)
        {
            try
            {
                Quiz quiz = await quizRepo.GetQuizForIdAsync(QuizId);
                if (quiz == null || QuizId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
                }
                await quizRepo.DeleteQuestion(id);
                return RedirectToAction(nameof(QuizQuestions), new { id = QuizId });
            }
            catch(Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }

        //Answers
        public async Task<IActionResult> QuestionAnswers(Guid id, Guid QuizId, string QuestionName)
        {
            try
            {
                Quiz quiz = await quizRepo.GetQuizForIdAsync(QuizId);
                if (quiz == null || QuizId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
                }
                Question question = await quizRepo.GetQuestionForIdAsync(id);
                if (question == null || id == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuestionId" });
                }
                ViewData["QuestionId"] = id;
                ViewData["QuizId"] = QuizId;
                IEnumerable<Answer> answers = await quizRepo.GetAllAnswersByQuestionId(id);
                ViewData["QuestionName"] = QuestionName;
                return View(answers);
            }
            catch(Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }
        public async Task<IActionResult> CreateAnswer(Guid id, Guid QuizId, bool createSingleAnswer)
        {
            try
            {
                Quiz quiz = await quizRepo.GetQuizForIdAsync(QuizId);
                if (quiz == null || QuizId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
                }
                IEnumerable<Answer> answers = await quizRepo.GetAllAnswersByQuestionId(id);
                var answerCount = answers.Count();
                Question question = await quizRepo.GetQuestionForIdAsync(id);
                if (question == null || id == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuestionId" });
                }
                ViewData["QuestionName"] = question.Description;
                ViewData["answersCount"] = answerCount;
                ViewData["QuestionId"] = id;
                ViewData["QuizId"] = QuizId;
                ViewData["CreateSingle"] = createSingleAnswer;
                return View();
            }
            catch (Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnswerSubmit(Guid id, IFormCollection collection, AnswerCreateViewModel answer, bool createSingleAnswer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                string uniqueFileName = null;
                if(answer.Foto != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName =  Guid.NewGuid().ToString() + "_" + answer.Foto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    answer.Foto.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Answer newAnswer = new Answer
                {
                    Id = Guid.NewGuid(),
                    Description = answer.Description,
                    FotoURL = uniqueFileName
                };

                if (answer.Correct.ToString() == "True")
                {
                    newAnswer.Correct = Answer.IsCorrect.True;
                }
                else
                {
                    newAnswer.Correct = Answer.IsCorrect.False;
                }

                newAnswer.QuestionId = id;
                Question question = await quizRepo.GetQuestionForIdAsync(id);
                if (question == null || id == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuestionId" });
                }
                newAnswer.Question = question;
                var created = await quizRepo.AddAnswer(newAnswer);
                if (created == null)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Answer failed to create" });
                }

                if (createSingleAnswer)
                {
                    return RedirectToAction(nameof(QuestionAnswers), new { id = question.Id, QuizId = question.QuizId, QuestionName = question.Description });
                }

                IEnumerable<Answer> answers = await quizRepo.GetAllAnswersByQuestionId(id);
                var answerCount = answers.Count();
                if (answerCount == 10)
                {
                    return RedirectToAction(nameof(QuizQuestions), new { id = question.QuizId });
                }
                else
                {
                    return RedirectToAction(nameof(CreateAnswer), new { id = id, QuizId = question.QuizId });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create is giving an error: " + ex.Message);
                return View();
            }
        }
        
        public async Task<IActionResult> EditAnswer(Guid id, Guid QuizId, string FotoURL)
        {
            try
            {
                Answer answer = await quizRepo.GetAnswerForIdAsync(id);
                if (answer == null || id == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong AnswerId" });
                }
                AnswerEditViewModel answerEdit = new AnswerEditViewModel
                {
                    Id = answer.Id,
                    Description = answer.Description,
                    FotoURL = answer.FotoURL,
                    QuestionId = answer.QuestionId
                };
                Question question = await quizRepo.GetQuestionForIdAsync(answer.QuestionId);

                Quiz quiz = await quizRepo.GetQuizForIdAsync(QuizId);
                if (quiz == null || QuizId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
                }

                ViewData["QuestionName"] = question.Description;
                ViewData["QuestionId"] = answer.QuestionId;
                ViewData["FotoURL"] = FotoURL;
                ViewData["IsCorrect"] = answer.Correct;
                ViewData["QuizId"] = QuizId;
                return View(answerEdit);
            }
            catch (Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnswer(Guid id, IFormCollection collection, AnswerEditViewModel answer, Guid QuizId, Guid QuestionId, string FotoURL)
        {
            try
            {
                answer.FotoURL = FotoURL;
                // TODO: Add update logic here
                Answer answerUpdate = new Answer
                {
                    Id = answer.Id,
                    Description = answer.Description,
                    QuestionId = answer.QuestionId,
                    FotoURL = answer.FotoURL
                };

                string uniqueFileName = null;
                if (answer.Foto != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + answer.Foto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    answer.Foto.CopyTo(new FileStream(filePath, FileMode.Create));
                    answerUpdate.FotoURL = uniqueFileName;
                }
                if (answer.Correct.ToString() == "True")
                {
                    answerUpdate.Correct = Answer.IsCorrect.True;
                }
                else
                {
                    answerUpdate.Correct = Answer.IsCorrect.False;
                }

                var result = await quizRepo.UpdateAnswer(answerUpdate);
                if (result == null)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Failed to update answer..." });
                }

                Quiz quiz = await quizRepo.GetQuizForIdAsync(QuizId);
                if (quiz == null || QuizId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuizId" });
                }

                Question question = await quizRepo.GetQuestionForIdAsync(QuestionId);
                if (question == null || QuestionId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuestionId" });
                }
                return RedirectToAction(nameof(QuestionAnswers), new { id = QuestionId, QuizId = QuizId, QuestionName = question.Description });
            }
            catch (Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }

        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            try
            {
                Answer answer = await quizRepo.GetAnswerForIdAsync(id);
                if (answer == null || id == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong AnswerId" });
                }
                Question question = null;
                question = await quizRepo.GetQuestionForIdAsync(answer.QuestionId);
                ViewData["QuizId"] = question.QuizId;
                ViewData["QuestionId"] = answer.QuestionId;
                if(answer.FotoURL != null)
                {
                    ViewData["FotoURL"] = answer.FotoURL;
                }
                else
                {
                    ViewData["FotoURL"] = "False";
                }
                return View(answer);
            }
            catch (Exception exc)
            {
                return RedirectToAction(nameof(Quizzes), new { exc = exc.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnswer(Guid id, IFormCollection collection, Guid QuizId, Guid QuestionId)
        {
            try
            {
                await quizRepo.DeleteAnswer(id);
                Question question = await quizRepo.GetQuestionForIdAsync(QuestionId);
                if (question == null || QuestionId == Guid.Empty)
                {
                    return RedirectToAction(nameof(Quizzes), new { exc = "Wrong QuestionId" });
                }
                return RedirectToAction(nameof(QuestionAnswers), new { id = QuestionId, QuizId = QuizId, QuestionName = question.Description });
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return View();
            }
        }
    }
}