using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizDerFlandriens.Models.Repositories
{
    public interface IQuizRepo
    {
        Task<Person> GetPersonForIdAsync(string id);
        Task<Question> AddQuestion(Question question);
        Task<Quiz> AddQuiz(Quiz quiz);
        Task DeleteQuestion(Guid QuestionId);
        Task DeleteQuiz(Guid QuizId);
        Task<IEnumerable<Question>> GetAllQuestionsByQuizId(Guid QuizId);
        Task<IEnumerable<Quiz>> GetAllQuizzesAsync();
        Task<Question> GetQuestionForIdAsync(Guid QuestionId);
        Task<Quiz> GetQuizForIdAsync(Guid QuizId);
        Task<Question> UpdateQuestion(Question question);
        Task<Quiz> UpdateQuiz(Quiz quiz);
        Task<Answer> AddAnswer(Answer answer);
        Task<IEnumerable<Answer>> GetAllAnswersByQuestionId(Guid QuestionId);
        Task<Answer> GetAnswerForIdAsync(Guid AnswerId);
        Task<Answer> UpdateAnswer(Answer answer);
        Task DeleteAnswer(Guid AnswerId);
        Task<Result> AddResult(Result resultobj);
        Task<IEnumerable<Result>> GetAllResultsByQuizId(Guid QuizId);
        Task<Result> GetResultByIdAsync(Guid ResultId);
        Task DeleteResult(Guid ResultId);
    }
}