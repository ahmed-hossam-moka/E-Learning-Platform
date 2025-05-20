using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.DAL.Repository.Quizs
{
    public interface IQuizRepository
    {

        Task CreateQuizAsync(Quiz quiz);

        Task<List<Quiz>> GetAllAsync(int courseId);
        Task<Quiz> GetByIdAsync(int id);

        Task RemoveById(int id);
        Task<int> CompleteAsync();

        public Task<List<Question>> GetQuestionsByQuizIdAsync(int quizId);




        Task<Quiz> GetQuizWithQuestionsAndChoicesAsync(int quizId);
        Task AddQuizResultAsync(QuizResult result);
        Task AddStudentAnswerAsync(StudentAnswer answer);

        Task SaveChangesAsync();



        public Task<QuizResult> GetByQuizResultIdAsync(int quizResultId);




        //Task CreateAsync(Quiz quiz);

        //Task<int> CompleteAsync();

        //Task<Quiz> GetFullQuizByIdAsync(int id);

        //Task<List<Question>> GetQuestionsByQuizIdAsync(int quizId);



    }
}
