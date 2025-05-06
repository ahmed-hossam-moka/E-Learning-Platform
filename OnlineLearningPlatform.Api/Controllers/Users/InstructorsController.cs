using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos.Users;
using OnlineLearningPlatform.BLL.Managers.Users;

namespace OnlineLearningPlatform.Api.Controllers.Users
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorManager _instructorManager;

        public InstructorsController(IInstructorManager instructorManager)
        {
            _instructorManager = instructorManager;
        }
        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public IActionResult GetAll()
        {
            var insructor = _instructorManager.GetAll();

            if (insructor == null)
                return NotFound("insructor Empty");

            return Ok(insructor);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(string Id)
        {
            var insructor = _instructorManager.GetById(Id);

            if (insructor == null)
                return NotFound("insructor Not Exist");

            return Ok(insructor);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(InstructorUpdateDto instructor, string Id)
        {
            if (Id != instructor.InstructorId)
                return BadRequest();

            _instructorManager.Update(instructor);

            return NoContent();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(string Id)
        {
            _instructorManager.Delete(Id);
            return NoContent();
        }
    }
}
