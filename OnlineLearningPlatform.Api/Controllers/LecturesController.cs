using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Managers;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly ILectureManager _lectureManager;

        public LecturesController(ILectureManager lectureManager)
        {
            _lectureManager = lectureManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lecture = _lectureManager.GetAll();

            if (lecture == null)
                return NotFound("No lectures");

            return Ok(lecture);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lecture = _lectureManager.GetById(id);

            if (lecture == null)
                return NotFound("No lectures");

            return Ok(lecture);
        }

        [HttpPost]
        public IActionResult Insert(LectureAddDto LectureAddDto)
        {
            _lectureManager.Insert(LectureAddDto);
            return RedirectToAction(nameof(GetAll), new { Message = "Created Successfully" });
        }

        [HttpPut("{Id}")]
        public IActionResult Update(LectureUpdateDto lecture, int Id)
        {
            if (Id != lecture.LectureId)
                return BadRequest();

            _lectureManager.Update(lecture);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _lectureManager.Delete(id);
            return NoContent();

        }
    }
}
