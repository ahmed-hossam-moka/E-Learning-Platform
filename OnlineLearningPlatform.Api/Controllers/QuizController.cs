using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos.Quizs;
using OnlineLearningPlatform.BLL.Managers.Quizs;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase

    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }


        [HttpGet("/courses/{courseId}/quizzes")]
        public async Task<IActionResult> GetAll(int courseId)
        {
            try
            {
                var quizzes = await _quizService.GetAllQuizzesAsync(courseId);
                return Ok(quizzes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-quiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizDto quizDto)
        {
            await _quizService.CreateQuizAsync(quizDto);
            return Ok(new { message = "Quiz created successfully" });
        }


        [HttpDelete("/quizzes/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var quiz = await _quizService.DeleteQuizAsync(id);
                return Ok("Quiz deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/quizzes/{quizId}/questions")]
        public async Task<IActionResult> GetQuizQuestions(int quizId)
        {
            var questions = await _quizService.GetQuizQuestionsAsync(quizId);
            return Ok(questions);
        }


        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] SubmitQuizDto dto)
        {
            var result = await _quizService.SubmitQuizAsync(dto);

            return Ok(result); 
        }


    }
}
