using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository.Quizs
{
    public interface IQuizResultRepository
    {
        Task<List<QuizResult>> GetByIdAsync(int id);
        Task CreateAsync(QuizResult quiz);
        Task<int> CompleteAsync();


    }
}
