using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos.Admin;
using OnlineLearningPlatform.BLL.Managers;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminManager _adminManager;

        public AdminController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        // GET: api/admin/pending-instructors
        [HttpGet("pending-instructors")]
        public IActionResult GetPendingInstructors()
        {
            var instructors = _adminManager.GetPendingInstructors();
            return Ok(instructors);
        }

        // GET: api/admin/pending-courses
        [HttpGet("pending-courses")]
        public IActionResult GetPendingCourses()
        {
            var courses = _adminManager.GetPendingCourses();
            return Ok(courses);
        }

        // POST: api/admin/approve-instructor
        [HttpPost("approve-instructor")]
        public IActionResult ApproveInstructor([FromBody] InstructorApprovalDto approvalDto)
        {
            _adminManager.ApproveInstructor(approvalDto);
            return NoContent();
        }

        // POST: api/admin/approve-course
        [HttpPost("approve-course")]
        public IActionResult ApproveCourse([FromBody] CourseApprovalDto approvalDto)
        {
            _adminManager.ApproveCourse(approvalDto);
            return NoContent();
        }

        // POST: api/admin/reject-instructor/{instructorId}
        [HttpPost("reject-instructor/{instructorId}")]
        public IActionResult RejectInstructor(string instructorId, [FromQuery] string? reason)
        {
            _adminManager.RejectInstructor(instructorId, reason);
            return NoContent();
        }

        // POST: api/admin/reject-course/{courseId}
        [HttpPost("reject-course/{courseId}")]
        public IActionResult RejectCourse(int courseId, [FromQuery] string? reason)
        {
            _adminManager.RejectCourse(courseId, reason);
            return NoContent();
        }
    }
}