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
    public class QuizController : ControllerBase
    {
        private IQuizRepo quizRepo;

        public QuizController(IQuizRepo quizRepo)
        {
            this.quizRepo = quizRepo;
        }

        // GET: api/Quiz
        [HttpGet]
        public async Task<ActionResult<List<Quiz_DTO>>> Get()
        {
            var model = await quizRepo.GetAllQuizzesAsync();
            List<Quiz_DTO> model_DTO = new List<Quiz_DTO>();
            foreach(Quiz quiz in model)
            {
                var result = new Quiz_DTO();
                model_DTO.Add(QuizMapper.ConvertQuizTo_DTO(quiz, ref result, quizRepo));
            }
            return Ok(model_DTO);
        }

        // GET: api/Quiz/{id}
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Quiz_DTO>> Get(Guid id)
        {
            var result = await quizRepo.GetQuizForIdAsync(id);
            if (result == null)
            {
                return BadRequest("Quiz not found");
            }
            var obj = new Quiz_DTO();
            var model = QuizMapper.ConvertQuizTo_DTO(result, ref obj, quizRepo);
            return Ok(model);
        }

        // POST: api/Quiz
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Quiz_DTO quiz_DTO)
        {
            var confirmedModel = new Quiz(); //te returnen DTO
            try
            {
                var obj = new Difficulty_DTO();
                quiz_DTO.Difficulty = QuizMapper.ConvertDifficultyTo_DTO(await quizRepo.GetDifficultyForIdAsync(quiz_DTO.DifficultyId), ref obj);
                //1. Validatie
                if (!ModelState.IsValid) { return BadRequest(ModelState); }
                //2.Entity (model) via de mapper ophalen
                var model = new Quiz() { };
                QuizMapper.ConvertQuizTo_Entity(quiz_DTO, ref model);
                //3. Entity (model) toevoegen via het repo
                confirmedModel = await quizRepo.AddQuiz(model);
                //4. Een bevestiging v foutieve actie teruggeven
                if (confirmedModel == null)
                    return NotFound(model.Subject + " did not get saved. ");
            }
            catch (Exception exc)
            {
                return BadRequest("Add quiz failed");
            }
            //5. DTO terugsturen als bevestiging
            return CreatedAtAction("Get", new { id = confirmedModel.Id }, quiz_DTO);
        }


        // PUT: api/Quiz/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromForm] Quiz_DTO quiz_DTO)
        {
            var confirmedModel = new Quiz(); //te returnen DTO
            try
            {
                //var obj = new Difficulty_DTO();
                //quiz_DTO.Difficulty = QuizMapper.ConvertDifficultyTo_DTO(await quizRepo.GetDifficultyForIdAsync(quiz_DTO.DifficultyId), ref obj);
                //1. Validatie
                if (!ModelState.IsValid) { return BadRequest(ModelState); }
                //2.Entity (model) via de mapper ophalen
                var model = new Quiz() { };
                QuizMapper.ConvertQuizTo_Entity(quiz_DTO, ref model);
                //3. Entity (model) toevoegen via het repo
                confirmedModel = await quizRepo.UpdateQuiz(model);
                //4. Een bevestiging v foutieve actie teruggeven
                if (confirmedModel == null)
                    return NotFound(model.Subject + " did not get saved. ");
            }
            catch (Exception exc)
            {
                return BadRequest("Update quiz failed");
            }
            //5. DTO terugsturen als bevestiging
            return CreatedAtAction("Get", new { id = confirmedModel.Id }, quiz_DTO);
        }

        // DELETE: api/Quiz/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await quizRepo.GetQuizForIdAsync(id);
            if (model != null)
            {
                await quizRepo.DeleteQuiz(id);
                return Ok("Quiz deleted");
            }
            else
            {
                return BadRequest("There is no quiz with this id...");
            }
        }
    }
}
