using Microsoft.EntityFrameworkCore;
using QuizDerFlandriens.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDerFlandriens.Models.Repositories
{
    public class QuizRepo : IQuizRepo
    {
        private readonly QuizDerFlandriensContext context;

        public QuizRepo(QuizDerFlandriensContext context)
        {
            this.context = context;
        }

        //Person
        public async Task<Person> GetPersonForIdAsync(string id)
        {
            try
            {
                var result = context.Persons.Where(e => e.Id == id).FirstOrDefault<Person>();

                return await Task.FromResult(result);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Person person = new Person();
                return person;
            }
        }

        //Difficulties
        public async Task<IEnumerable<Difficulty>> GetAllDifficultiesAsync()
        {
            var result = context.Difficulties;
            return await Task.FromResult(result);
        }

        //Quiz
        public async Task<Quiz> AddQuiz(Quiz quiz)
        {
            try
            {
                var result = context.Quizzes.AddAsync(quiz);
                await context.SaveChangesAsync();
                return quiz;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }
        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            var result = context.Quizzes.Include(e => e.Difficulty).OrderByDescending(e => e.Subject);
            return await Task.FromResult(result);
        }
        public async Task<Quiz> GetQuizForIdAsync(Guid QuizId)
        {
            try
            {
                var result = context.Quizzes.Include(e => e.Results).Include(e => e.Difficulty).Where(e => e.Id == QuizId).FirstOrDefault<Quiz>();

                return await Task.FromResult(result);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Quiz quiz = new Quiz();
                return quiz;
            }
        }
        public async Task<Quiz> UpdateQuiz(Quiz quiz)
        {
            try
            {
                context.Quizzes.Update(quiz);
                await context.SaveChangesAsync();
                return quiz;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }
        public async Task DeleteQuiz(Guid QuizId)
        {
            try
            {
                Quiz quiz = await GetQuizForIdAsync(QuizId);

                if (QuizId == null)
                {
                    return;
                }

                context.Questions.RemoveRange(context.Questions.Where(e => e.QuizId == QuizId).Include(e => e.Answers));

                var result = context.Quizzes.Remove(quiz);

                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }

        //Questions
        public async Task<Question> AddQuestion(Question question)
        {
            try
            {
                var result = context.Questions.AddAsync(question);
                await context.SaveChangesAsync();
                return question;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }
        public async Task<IEnumerable<Question>> GetAllQuestionsByQuizId(Guid QuizId)
        {
            var result = context.Questions.Where(e => e.QuizId == QuizId).OrderByDescending(e => e.Description);
            return await Task.FromResult(result);
        }
        public async Task<Question> GetQuestionForIdAsync(Guid QuestionId)
        {
            var result = context.Questions.Include(e => e.Answers).Include(e => e.Quiz).Where(e => e.Id == QuestionId).FirstOrDefault<Question>();
            return await Task.FromResult(result);
        }
        public async Task<Question> UpdateQuestion(Question question)
        {
            try
            {
                context.Questions.Update(question);
                await context.SaveChangesAsync();
                return question;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }
        public async Task DeleteQuestion(Guid QuestionId)
        {
            try
            {
                Question question = await GetQuestionForIdAsync(QuestionId);

                if (QuestionId == null)
                {
                    return;
                }

                var result = context.Questions.Remove(question);
                ////doe hier een archivering van education ipv delete -> veiliger
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }

        //Answers
        public async Task<Answer> AddAnswer(Answer answer)
        {
            try
            {
                var result = context.Answers.AddAsync(answer);
                await context.SaveChangesAsync();
                return answer;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }
        public async Task<IEnumerable<Answer>> GetAllAnswersByQuestionId(Guid QuestionId)
        {
            var result = context.Answers.Include(e => e.Question).Where(e => e.QuestionId == QuestionId).OrderByDescending(e => e.Description);
            return await Task.FromResult(result);
        }
        public async Task<Answer> GetAnswerForIdAsync(Guid AnswerId)
        {
            var result = context.Answers.Include(e => e.Question).Where(e => e.Id == AnswerId).FirstOrDefault<Answer>();
            return await Task.FromResult(result);
        }
        public async Task<Answer> UpdateAnswer(Answer answer)
        {
            try
            {
                context.Answers.Update(answer);
                await context.SaveChangesAsync();
                return answer;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
        }
        public async Task DeleteAnswer(Guid AnswerId)
        {
            try
            {
                Answer answer = await GetAnswerForIdAsync(AnswerId);

                if (AnswerId == null)
                {
                    return;
                }

                var result = context.Answers.Remove(answer);
                ////doe hier een archivering van education ipv delete -> veiliger
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }

        //Results
        public async Task<Result> AddResult(Result resultobj)
        {
            try
            {
                var result = context.Results.AddAsync(resultobj);
                await context.SaveChangesAsync();
                return resultobj;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }
        public async Task<IEnumerable<Result>> GetAllResultsByQuizId(Guid QuizId)
        {
            var result = context.Results.Include(e => e.Person).Where(e => e.QuizId == QuizId).OrderByDescending(e => e.Score);
            return await Task.FromResult(result);
        }
        public async Task<Result> GetResultByIdAsync(Guid ResultId)
        {
            var result = context.Results.Where(e => e.Id == ResultId).Include(e => e.Quiz).Include(e => e.Person).FirstOrDefault<Result>();
            return await Task.FromResult(result);
        }
        public async Task DeleteResult(Guid ResultId)
        {
            try
            {
                Result resultobj = await GetResultByIdAsync(ResultId);

                if (ResultId == null)
                {
                    return;
                }

                var result = context.Results.Remove(resultobj);
                ////doe hier een archivering van education ipv delete -> veiliger
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }

    }
}
