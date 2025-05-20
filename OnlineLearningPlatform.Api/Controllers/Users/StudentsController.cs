using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos.Users;
using OnlineLearningPlatform.BLL.Managers.Users;

namespace OnlineLearningPlatform.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public StudentsController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var student = _studentManager.GetAll();
            if (student == null)
                return NotFound("Student Empty");
            return Ok(student);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(string Id)
        {
            var student = _studentManager.GetById(Id);

            if (student == null)
                return NotFound("student Not Exist");

            return Ok(student);

        }

        [HttpPut("{Id}")]
        public IActionResult Update(StudentUpdateDto studentUpdateDto, string Id)
        {
            if (Id != studentUpdateDto.StudentId)
                return BadRequest();

            _studentManager.Update(studentUpdateDto);

            return NoContent();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(string Id)
        {
            _studentManager.Delete(Id);
            return NoContent();
        }
    }
}
