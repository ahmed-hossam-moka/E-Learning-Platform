using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.MVC.Models.Quiz;
using OnlineLearningPlatform.MVC.Services;
using System.Security.Claims;

namespace OnlineLearningPlatform.MVC.Controllers
{
    //[Authorize(Roles = "Student")]
    public class StudentQuizController : Controller
    {
        private readonly IQuizApiService _quizApiService;

        public StudentQuizController(IQuizApiService quizApiService)
        {
            _quizApiService = quizApiService;
        }



        [HttpGet("student/courses/{courseId}/quizzes")]
        public async Task<IActionResult> Index(int courseId)
        {
            var quizzes = await _quizApiService.GetQuizzesByCourse(courseId);
            ViewBag.CourseId = courseId;
            return View(quizzes);
        }

        //quizzes/take/Quiz Id
        [HttpGet("quizzes/take/{quizId}")]
        public async Task<IActionResult> TakeQuiz(int quizId)
        {
            var questions = await _quizApiService.GetQuizQuestions(quizId);
            var model = new SubmitQuizViewModel
            {
                QuizId = quizId,
                StudentId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Answers = questions.Select(q => new StudentAnswerViewModel
                {
                    QuestionId = q.QuestionId
                }).ToList()
            };

            ViewBag.Questions = questions;
            return View(model);
        } // tested done

        [HttpPost("quizzes/submit")]
        public async Task<IActionResult> SubmitQuiz(SubmitQuizViewModel model)
        {
            model.StudentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                var questions = await _quizApiService.GetQuizQuestions(model.QuizId);
                ViewBag.Questions = questions;
                return View("TakeQuiz", model);
            }

            var result = await _quizApiService.SubmitQuiz(model);
            return RedirectToAction("QuizResult", new { quizId = model.QuizId, resultId = result.QuizResultId });
        } // tested done

        [HttpGet("quizzes/result/{quizId}/{resultId}")]
        public async Task<IActionResult> QuizResult(int quizId, int resultId)
        {
            var result = await _quizApiService.GetQuizResult(resultId);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);

        }// tested Done
    }
}