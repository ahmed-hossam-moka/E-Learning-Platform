using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Managers;

namespace OnlineLearningPlatform.Api.Controllers
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

        public IActionResult GetAll()
        {
            var insructor = _instructorManager.GetAll();

            if (insructor == null)
                return NotFound("insructor Empty");

            return Ok(insructor);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var insructor = _instructorManager.GetById(Id);

            if (insructor == null)
                return NotFound("insructor Not Exist");

            return Ok(insructor);
        }
        [HttpPost]
        public IActionResult Add(InstructorAddDto instructorAddDto)
        {
            _instructorManager.Add(instructorAddDto);
            return RedirectToAction(nameof(GetAll), new { Message = "Created Successfully" });
        }

        [HttpPut("{Id}")]
        public IActionResult Update(InstructorUpdateDto instructor, int Id)
        {
            if (Id != instructor.InstructorId)
                return BadRequest();

            _instructorManager.Update(instructor);

            return NoContent();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _instructorManager.Delete(Id);
            return NoContent();
        }
    }
}
