using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatformMVC.Models.AhmedTasks;


namespace OnlineLearningPlatformMVC.Controllers.AhmedTasks
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
