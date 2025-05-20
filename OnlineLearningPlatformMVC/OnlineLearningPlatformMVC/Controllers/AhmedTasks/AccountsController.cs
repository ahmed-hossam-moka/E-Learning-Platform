using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatformMVC.Models.AhmedTasks;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlineLearningPlatformMVC.Controllers.AhmedTasks
{
    public class AccountsController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7234/api/");
        }

        //Accounts/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            var result = await _httpClient.PostAsJsonAsync<RegisterVM>($"Accounts/", registerVM);

            result.EnsureSuccessStatusCode();

            return View(result);
        }
        //Accounts/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var result = await _httpClient.PostAsJsonAsync<LoginVM>($"Accounts/", loginVM);

            result.EnsureSuccessStatusCode();

            return View(result);
        }
    }
}
