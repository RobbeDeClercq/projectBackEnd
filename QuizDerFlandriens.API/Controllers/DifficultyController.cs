using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizDerFlandriens.API.Models;
using QuizDerFlandriens.Models;
using QuizDerFlandriens.Models.Repositories;

namespace QuizDerFlandriens.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private IQuizRepo quizRepo;

        public DifficultyController(IQuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        // GET: api/Difficulty
        [HttpGet]
        public async Task<ActionResult<List<Difficulty_DTO>>> Get()
        {
            var model = await quizRepo.GetAllDifficultiesAsync();
            List<Difficulty_DTO> model_DTO = new List<Difficulty_DTO>();
            foreach(Difficulty difficulty in model)
            {
                var result = new Difficulty_DTO();
                model_DTO.Add(QuizMapper.ConvertDifficultyTo_DTO(difficulty, ref result));
            }
            return Ok(model_DTO);
        }
    }
}
