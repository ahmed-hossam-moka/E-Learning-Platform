using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatformMVC.Models.AhmedTasks;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlineLearningPlatformMVC.Controllers.AhmedTasks
{
    public class InstructorsController : Controller
    {
        private readonly HttpClient _httpClient;

        public InstructorsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7234/api/");
        }

        //Instructors/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<InstructorReadVM>>("Instructors/");

            if (result == null || !result.Any())
                return Content("No Instructors Data...");

            return View(result);
        }

        //Instructors/GetById
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<InstructorReadVM>($"Instructors/{Id}");

            if (result == null)
                return Content("No Instructor Data...");

            return View(result);
        }

        ////Instructors/Add
        //[HttpPost]
        //public async Task<IActionResult> Add(InstructorAddVM instructorAddVM)
        //{
        //    var result = await _httpClient.PostAsJsonAsync<InstructorAddVM>($"Instructors/", instructorAddVM);

        //    result.EnsureSuccessStatusCode();

        //    return View(result);
        //}

        //Instructors/Update
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(InstructorUpdateVM instructorUpdateVM,int Id)
        {
            var result = await _httpClient.PutAsJsonAsync<InstructorUpdateVM>($"Instructors/{Id}", instructorUpdateVM);

            result.EnsureSuccessStatusCode();

            return Ok(result.Content.ReadAsStringAsync().IsCompletedSuccessfully);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _httpClient.DeleteAsync($"Instructors/{Id}");

            result.EnsureSuccessStatusCode();
            return Ok(result.Content.ReadAsStringAsync().IsCompletedSuccessfully);
        }


    }
}
