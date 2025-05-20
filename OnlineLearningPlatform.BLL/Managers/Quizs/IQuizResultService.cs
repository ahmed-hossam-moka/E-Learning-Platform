using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Dtos.Quizs;

namespace OnlineLearningPlatform.BLL.Managers.Quizs
{
    public interface IQuizResultService
    {
        Task<List<QuizResultDto>> GetQuizResultsAsync(int quizId);
        Task<QuizResultDto> CreateQuizResultAsync(CreateQuizResultDto createQuizResultDto);

    }
}
