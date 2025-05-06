using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Managers;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentManager _enrollmentManager;

        public EnrollmentController(IEnrollmentManager enrollmentManager)
        {
            _enrollmentManager = enrollmentManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var enrollments = _enrollmentManager.GetAll();

            if (enrollments == null)
                return NotFound("enrollments Empty");

            return Ok(enrollments);
        }

        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var enrollment = _enrollmentManager.GetById(Id);

            if (enrollment == null)
                return NotFound("enrollment Empty");

            return Ok(enrollment);

        }

        [HttpPost]
        public ActionResult Insert(EnrollmentAddDto enrollmentAddDto)
        {
            _enrollmentManager.Insert(enrollmentAddDto);
            return CreatedAtAction(nameof(GetById), new { Id = enrollmentAddDto.StudentId }, new { Message = "Created Successfully" });
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _enrollmentManager.Delete(Id);
            return NoContent();
        }

    }
}
