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



        //Task AddQuestionAsync(CreateQuestionDto dto);

    }
}
