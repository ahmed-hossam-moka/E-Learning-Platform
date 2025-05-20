using OnlineLearningPlatform.BLL.Dtos.Quizs;

namespace OnlineLearningPlatform.BLL.Managers.Quizs
{
    public interface IQuizService
    {
        Task<List<QuizToReturnDto>> GetAllQuizzesAsync(int courseId);

        Task CreateQuizAsync(CreateQuizDto createQuizDto);

        Task<int> DeleteQuizAsync(int id);

        public Task<List<QuestionWithChoicesDto>> GetQuizQuestionsAsync(int quizId);


        Task<QuizResultDto> SubmitQuizAsync(SubmitQuizDto dto);


        public  Task<QuizResultDto> GetQuizResultByIdAsync(int quizResultId);




        //Task AddQuestionAsync(CreateQuestionDto dto);

    }
}
