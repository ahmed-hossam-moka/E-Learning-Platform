using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Managers;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseManager _courseManager;

        public CoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var Courses = _courseManager.GetAll();
            if (Courses == null)
                return NotFound("No Courses Found");
            else
                return Ok(Courses);

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var Course = _courseManager.GetById(Id);
            if (Course == null)
                return NotFound("No Course Found");
            else
                return Ok(Course);
        }
        [HttpPost]
        public ActionResult Add(CourseAddDto course)
        {
            _courseManager.Add(course);
            return CreatedAtAction(nameof(GetById),new {Id=course.CourseId},new {Message="created successfully"});
        }
        [HttpPut("{Id}")]
        public ActionResult Update(int Id,CourseUpdateDto Course)
        {
            if (Id != Course.CourseId)
                return BadRequest();
            _courseManager.Update(Course);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _courseManager.Delete(Id);
            return NoContent();
        }
    }
}
