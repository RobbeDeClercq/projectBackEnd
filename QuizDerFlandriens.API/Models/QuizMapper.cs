using QuizDerFlandriens.Models;
using QuizDerFlandriens.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizDerFlandriens.API.Models
{
    public class QuizMapper
    {
        public static Quiz ConvertQuizTo_Entity(Quiz_DTO quiz_DTO, ref Quiz quiz)
        {
            quiz.Id = quiz_DTO.Id;
            quiz.DifficultyId = quiz_DTO.DifficultyId;
            quiz.Description = quiz_DTO.Description;
            quiz.Subject = quiz_DTO.Subject;

            return quiz;
        }

        public static Difficulty ConvertDifficultyTo_Entity(Difficulty_DTO difficulty_DTO, ref Difficulty difficulty)
        {
            difficulty.Id = difficulty_DTO.Id;
            difficulty.Description = difficulty_DTO.Description;

            return difficulty;
        }

        public static Difficulty_DTO ConvertDifficultyTo_DTO(Difficulty difficulty, ref Difficulty_DTO difficulty_DTO)
        {
            difficulty_DTO.Id = difficulty.Id;
            difficulty_DTO.Description = difficulty.Description;
            return difficulty_DTO;
        }

        public static Quiz_DTO ConvertQuizTo_DTO(Quiz quiz, ref Quiz_DTO quiz_DTO, IQuizRepo quizRepo)
        {
            quiz_DTO.Id = quiz.Id;
            quiz_DTO.DifficultyId = quiz.DifficultyId;
            quiz_DTO.Subject = quiz.Subject;
            quiz_DTO.Description = quiz.Description;

            var diff = new Difficulty_DTO();
            quiz_DTO.Difficulty = ConvertDifficultyTo_DTO(quiz.Difficulty, ref diff);

            List<Question_DTO> question_DTOs = new List<Question_DTO>();
            //Questions
            foreach(Question question in quiz.Questions)
            {
                var obj = new Question_DTO();
                question_DTOs.Add(ConvertQuestionTo_DTO(question, obj, quizRepo).Result);
            }

            quiz_DTO.Questions = question_DTOs;

            List<Result_DTO> result_DTOs = new List<Result_DTO>();
            //results
            foreach(Result result in quiz.Results)
            {
                var obj = new Result_DTO();
                result_DTOs.Add(ConvertResultTo_DTO(result, ref obj));
            }

            quiz_DTO.Results = result_DTOs;

            return quiz_DTO;
        }

        public static Result_DTO ConvertResultTo_DTO(Result result, ref Result_DTO result_DTO)
        {
            result_DTO.Id = result.Id;
            result_DTO.Score = result.Score;

            return result_DTO;
        }

        public async static Task<Question_DTO> ConvertQuestionTo_DTO(Question question, Question_DTO question_DTO, IQuizRepo quizRepo)
        {
            question_DTO.Id = question.Id;
            question_DTO.Description = question.Description;

            var result = await quizRepo.GetAllAnswersByQuestionId(question.Id);
            List<Answer_DTO> answer_DTOs = new List<Answer_DTO>();
            //Answers
            foreach(Answer answer in result)
            {
                var obj = new Answer_DTO();
                answer_DTOs.Add(ConvertAnswerTo_DTO(answer, ref obj));
            }
            question_DTO.Answers = answer_DTOs;

            return question_DTO;
        }

        public static Answer_DTO ConvertAnswerTo_DTO(Answer answer, ref Answer_DTO answer_DTO)
        {
            answer_DTO.Id = answer.Id;
            answer_DTO.Description = answer.Description;
            answer_DTO.FotoURL = answer.FotoURL;
            if (answer.Correct.ToString() == "True")
            {
                answer_DTO.Correct = Answer_DTO.IsCorrect.True;
            }
            else
            {
                answer_DTO.Correct = Answer_DTO.IsCorrect.False;
            }

            return answer_DTO;
        }


    }
}
