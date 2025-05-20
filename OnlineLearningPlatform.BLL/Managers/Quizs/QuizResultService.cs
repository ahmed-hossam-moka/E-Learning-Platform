using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Dtos.Quizs;
using OnlineLearningPlatform.DAL.Models;
using OnlineLearningPlatform.DAL.Repository.Quizs;

namespace OnlineLearningPlatform.BLL.Managers.Quizs
{
    public class QuizResultService : IQuizResultService
    {
        private readonly IQuizResultRepository _quizResultRepository;

        public QuizResultService(IQuizResultRepository quizResultRepository)
        {
            _quizResultRepository = quizResultRepository;
        }


        public async Task<List<QuizResultDto>> GetQuizResultsAsync(int quizId)
        {
            var QuizResults = await _quizResultRepository.GetByIdAsync(quizId);

            return QuizResults.Select(qr => new QuizResultDto
            {
                Ispassed = qr.Ispassed,
                TakenAt = qr.TakenAt,
                QuizId = qr.QuizId,
                QuizResultId = qr.QuizResultId,
                Score = qr.Score,
                StudentId = qr.StudentId
            }).ToList();

        }
        public async Task<QuizResultDto> CreateQuizResultAsync(CreateQuizResultDto createQuizResultDto)
        {
            var quizResult = new QuizResult()
            {
                Ispassed = createQuizResultDto.Ispassed,
                StudentId = createQuizResultDto.StudentId,
                QuizId = createQuizResultDto.QuizId,
                Score = createQuizResultDto.Score,
                TakenAt = DateTime.UtcNow 

            };
            await _quizResultRepository.CreateAsync(quizResult);
            await _quizResultRepository.CompleteAsync();


            return new QuizResultDto
            {
                Ispassed = createQuizResultDto.Ispassed,
                TakenAt = DateTime.UtcNow,
                QuizId = createQuizResultDto.QuizId,
                Score = createQuizResultDto.Score,
                StudentId = createQuizResultDto.StudentId
            };

        }
    }
}
