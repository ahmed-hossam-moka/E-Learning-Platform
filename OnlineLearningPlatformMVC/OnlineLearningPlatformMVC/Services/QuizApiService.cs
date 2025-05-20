using System.Net.Http.Json;
using OnlineLearningPlatform.MVC.Models.Quiz;

namespace OnlineLearningPlatform.MVC.Services
{
    public class QuizApiService : IQuizApiService
    {
        private readonly HttpClient _httpClient;

        public QuizApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7234/");
        }

        public async Task<List<QuizViewModel>> GetQuizzesByCourse(int courseId) // Tested Done
        {
            var response = await _httpClient.GetAsync($"/courses/{courseId}/quizzes");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<QuizViewModel>>();
        }
        public async Task<bool> CreateQuiz(CreateQuizViewModel quiz)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/quiz/create-quiz", quiz);
            return response.IsSuccessStatusCode;
        } // Tested Done


        public async Task<List<QuestionViewModel>> GetQuizQuestions(int quizId)
        {
            var response = await _httpClient.GetAsync($"/quizzes/{quizId}/questions"); 
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<QuestionViewModel>>();
        } //tested Done

        public async Task<QuizResultViewModel> SubmitQuiz(SubmitQuizViewModel submitQuiz)
        {
            submitQuiz.StudentId = "8ef3e484-9df5-4e9e-accb-bba7d984ada0";
            var response = await _httpClient.PostAsJsonAsync("api/Quiz/submit", submitQuiz);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<QuizResultViewModel>();
        } //tested Done


        public async Task<QuizResultViewModel> GetQuizResult(int resultId)
        {
            var response = await _httpClient.GetAsync($"api/Quiz/quiz-results/{resultId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<QuizResultViewModel>();
        }// tested Done
    }
}