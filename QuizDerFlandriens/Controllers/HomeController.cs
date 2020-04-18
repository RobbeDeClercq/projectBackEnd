using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizDerFlandriens.Models;
using QuizDerFlandriens.Models.Repositories;

namespace QuizDerFlandriens.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IQuizRepo quizRepo;

        public HomeController(ILogger<HomeController> logger, IQuizRepo quizRepo)
        {
            _logger = logger;
            this.quizRepo = quizRepo;
        }

        public async Task Test()
        {
            return;
            //await quizRepo.DeleteQuiz(Guid.Parse("70dc72d4-ca07-48eb-8e0e-df2d567f5b62"));
            //return;

            //Quiz quiz = await quizRepo.GetQuizForIdAsync(Guid.Parse("4BE21245-2FCE-433E-B30E-D6585302675E"));
            //quiz.Description = "Dit is een update test";
            //await quizRepo.UpdateQuiz(quiz);
            //return quiz;

            //Quiz quiz = new Quiz();
            //quiz.DifficultyId = Guid.Parse("3B22E5A7-9495-4D88-BDC4-3BB4478109F0");
            //quiz.Subject = "testAdd";
            //quiz.Description = "dit is een toevoeg test";
            //Person person = await quizRepo.GetPersonForIdAsync("4f55a39f-c4b9-4772-9031-0e0dffd28e13");
            //quiz.Person = person;
            //await quizRepo.AddQuiz(quiz);
            //return quiz;


            //Quiz quiz = await quizRepo.GetQuizForIdAsync(Guid.Parse("70dc72d4-ca07-48eb-8e0e-df2d567f5b62"));
            //Console.WriteLine(quiz.Description);
            //return quiz;

            //IEnumerable<Quiz> quizzes = await quizRepo.GetAllQuizzesAsync();
            //foreach(Quiz quiz in quizzes)
            //{
            //    Console.WriteLine(quiz.Description);
            //}
            //return quizzes;
        }

        public IActionResult Index()
        {
            //Test();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
