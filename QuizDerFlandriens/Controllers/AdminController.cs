﻿using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> Quizzes()
        {
            IEnumerable<Quiz> quizzes = null;
            quizzes = await quizRepo.GetAllQuizzesAsync();
            foreach(Quiz quiz in quizzes)
            {
                IEnumerable<Question> questionsEnum = await quizRepo.GetAllQuestionsByQuizId(quiz.Id);
                foreach(Question question in questionsEnum)
                {
                    IEnumerable<Answer> answersEnum = await quizRepo.GetAllAnswersByQuestionId(question.Id);
                    List<Answer> answers = answersEnum.ToList();
                    question.Answers = answers;
                }
                List<Question> questions = questionsEnum.ToList();
                quiz.Questions = questions;
            }
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
            Quiz quiz = await quizRepo.GetQuizForIdAsync(id);
            ViewData["QuizName"] = quiz.Subject;
            IEnumerable<Question> questions = null;
            questions = await quizRepo.GetAllQuestionsByQuizId(id);
            foreach (Question question in questions)
            {
                IEnumerable<Answer> answersEnum = await quizRepo.GetAllAnswersByQuestionId(question.Id);
                List<Answer> answers = answersEnum.ToList();
                question.Answers = answers;
            }
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
        public async Task<IActionResult> QuestionAnswers(Guid id, Guid QuizId, string QuestionName)
        {
            ViewData["QuestionId"] = id;
            ViewData["QuizId"] = QuizId;
            IEnumerable<Answer> answers = await quizRepo.GetAllAnswersByQuestionId(id);
            ViewData["QuestionName"] = QuestionName;
            return View(answers);
        }
        public async Task<IActionResult> CreateAnswer(Guid id, Guid QuizId, bool createSingleAnswer)
        {
            IEnumerable<Answer> answers = await quizRepo.GetAllAnswersByQuestionId(id);
            var answerCount = answers.Count();
            if (createSingleAnswer)
            {
                Question question = await quizRepo.GetQuestionForIdAsync(id);
                ViewData["QuestionName"] = question.Description;
            }
            ViewData["answersCount"] = answerCount;
            ViewData["QuestionId"] = id;
            ViewData["QuizId"] = QuizId;
            ViewData["CreateSingle"] = createSingleAnswer;
            return View();
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
                newAnswer.Question = question;
                var created = await quizRepo.AddAnswer(newAnswer);
                if (created == null)
                {
                    throw new Exception("Invalid Entry");
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
            Answer answer = await quizRepo.GetAnswerForIdAsync(id);
            AnswerEditViewModel answerEdit = new AnswerEditViewModel
            {
                Id = answer.Id,
                Description = answer.Description,
                FotoURL = answer.FotoURL,
                QuestionId = answer.QuestionId
            };
            Question question = await quizRepo.GetQuestionForIdAsync(answer.QuestionId);
            ViewData["QuestionName"] = question.Description;
            ViewData["QuestionId"] = answer.QuestionId;
            ViewData["FotoURL"] = FotoURL;
            ViewData["IsCorrect"] = answer.Correct;
            ViewData["QuizId"] = QuizId;
            return View(answerEdit);
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
                    throw new Exception("Invalid Entry");
                }
                Question question = await quizRepo.GetQuestionForIdAsync(QuestionId);
                return RedirectToAction(nameof(QuestionAnswers), new { id = QuestionId, QuizId = QuizId, QuestionName = question.Description });
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            Answer answer = await quizRepo.GetAnswerForIdAsync(id);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnswer(Guid id, IFormCollection collection, Guid QuizId, Guid QuestionId)
        {
            try
            {
                await quizRepo.DeleteAnswer(id);
                Question question = await quizRepo.GetQuestionForIdAsync(QuestionId);
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