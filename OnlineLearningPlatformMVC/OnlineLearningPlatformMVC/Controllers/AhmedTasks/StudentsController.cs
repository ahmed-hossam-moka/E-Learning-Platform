using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatformMVC.Models.AhmedTasks;
using System.Net.Http;

namespace OnlineLearningPlatformMVC.Controllers.AhmedTasks
{
    public class StudentsController : Controller
    {
        private readonly HttpClient _httpClient;

        public StudentsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7234/api/");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<StudentReadVM>>("Students/");

            if (result == null || !result.Any())
                return Content("No Students Data...");

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<StudentReadVM>($"Students/{Id}");

            if (result == null)
                return Content("No Student Data...");

            return View(result);
        }
    }
}
