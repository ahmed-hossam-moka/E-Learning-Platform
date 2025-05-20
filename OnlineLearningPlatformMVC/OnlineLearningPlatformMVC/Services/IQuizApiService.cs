using System.Net.Http.Json;
using OnlineLearningPlatform.MVC.Models.Quiz;

namespace OnlineLearningPlatform.MVC.Services
{
    public interface IQuizApiService
    {
        Task<List<QuizViewModel>> GetQuizzesByCourse(int courseId);
        Task<QuizResultViewModel> SubmitQuiz(SubmitQuizViewModel submitQuiz);
        Task<List<QuestionViewModel>> GetQuizQuestions(int quizId);
        Task<bool> CreateQuiz(CreateQuizViewModel quiz);
        Task<QuizResultViewModel> GetQuizResult(int quizId);
    }

}