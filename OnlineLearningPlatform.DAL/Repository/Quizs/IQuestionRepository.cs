using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.DAL.Repository.Quizs
{
    public interface IQuestionRepository
    {
        Task<Question> GetByIdAsync(int id);
        Task<List<Question>> GetAllByQuizIdAsync(int quizId);
        Task AddAsync(Question question);
        Task<int> CompleteAsync();
        Task<List<Question>> GetQuestionsByQuizIdAsync(int quizId);




    }
}
