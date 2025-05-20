using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Managers;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLectureProgressController : ControllerBase
    {
        private readonly IUserLectureProgressService _userLectureProgressService;

        public UserLectureProgressController(IUserLectureProgressService userLectureProgressService)
        {
            _userLectureProgressService = userLectureProgressService;
        }
        [HttpGet("/students/{studentId}/progress")]
        public async Task<IActionResult> ViewStudentProgress(string studentId)
        {
            var result = await _userLectureProgressService.ViewStudentProgressAsync(studentId);
            return Ok(result);

        }
        [HttpPatch("/progress/{StudentId}")]
        public async Task<IActionResult> MarkLectureAsCompleted(string StudentId)
        {
            await _userLectureProgressService.MarkAsCompletedAsync(StudentId);
            return Ok("Mark lecture completed successfully");
        }

    }
}
