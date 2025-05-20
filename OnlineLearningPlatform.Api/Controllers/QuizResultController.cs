using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Dtos.Quizs;
using OnlineLearningPlatform.BLL.Managers.Quizs;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : ControllerBase
    {
        private readonly IQuizResultService _quizResultService;
        private readonly IQuizSubmissionService _quizSubmissionService;

        public QuizResultController(
            IQuizResultService quizResultService,
            IQuizSubmissionService quizSubmissionService)
        {
            _quizResultService = quizResultService;
            _quizSubmissionService = quizSubmissionService;
        }

        // ✅ استرجاع النتائج QuizResults
        [HttpGet("/quizzes/{quizId}/results")]
        public async Task<IActionResult> GetResults(int quizId)
        {
            var results = await _quizResultService.GetQuizResultsAsync(quizId);
            return Ok(results);
        }

        // ✅ إرسال الكويز (Submit)
        [HttpPost("/quizzes/submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] SubmitQuizDto dto)
        {
            var result = await _quizSubmissionService.SubmitQuizAsync(dto);
            return Ok(result);
        }
    }
}
