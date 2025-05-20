using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.MVC.Models.Quiz;
using OnlineLearningPlatform.MVC.Services;

namespace OnlineLearningPlatform.MVC.Controllers
{
    //[Authorize(Roles = "Instructor")]
    public class QuizController : Controller
    {
        private readonly IQuizApiService _quizApiService;

        public QuizController(IQuizApiService quizApiService)
        {
            _quizApiService = quizApiService;
        }


        //courses/Course Id/quizzes
        [HttpGet("courses/{courseId}/quizzes")]
        public async Task<IActionResult> Index(int courseId)
        {
            var quizzes = await _quizApiService.GetQuizzesByCourse(courseId);
            ViewBag.CourseId = courseId;
            return View(quizzes);
        }  // Tested Done

        //quizzes/create/Course Id
        [HttpGet("quizzes/create/{courseId}")]
        public IActionResult Create(int courseId)
        {
            var model = new CreateQuizViewModel { CourseId = courseId };
            return View(model);
        } //Tested Done

        [HttpPost("instructor/quizzes/create")]
        public async Task<IActionResult> Create(CreateQuizViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _quizApiService.CreateQuiz(model);
            if (success)
            {
                return RedirectToAction("Index", new { courseId = model.CourseId });
            }

            ModelState.AddModelError("", "Failed to create quiz. Please try again.");
            return View(model);
        } // Tested Done




        [HttpPost("quizzes/add-question")]
        public IActionResult AddQuestion(CreateQuizViewModel model)
        {
            model.Questions.Add(new CreateQuestionViewModel());
            return View("Create", model);
        }

        [HttpPost("quizzes/add-choice")]
        public IActionResult AddChoice(CreateQuizViewModel model, int questionIndex)
        {
            model.Questions[questionIndex].Choices.Add(new CreateChoiceViewModel());
            return View("Create", model);
        }

        [HttpPost("quizzes/delete/{id}")]
        public async Task<IActionResult> Delete(int id, int courseId)
        {
            // Note: You'll need to add a Delete method to your IQuizApiService
            // For now, this is just a placeholder
            return RedirectToAction("Index", new { courseId });
        }
    }
}