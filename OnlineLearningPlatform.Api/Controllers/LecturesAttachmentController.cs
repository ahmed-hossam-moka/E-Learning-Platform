using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Managers;
using OnlineLearningPlatform.DAL.Models;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesAttachmentController : ControllerBase
    {
        private readonly ILectureAttachmentManager _lectureAttachmentManager;

        public LecturesAttachmentController(ILectureAttachmentManager lectureAttachmentManager)
        {
            _lectureAttachmentManager = lectureAttachmentManager;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lectureAttachment = _lectureAttachmentManager.GetById(id);

            if (lectureAttachment == null)
                return NotFound("No lectureAttachment");

            return Ok(lectureAttachment);
        }

        [HttpPost]
        public IActionResult Insert(LectureAttachmentAddDto LectureAttachmentAddDto)
        {
            _lectureAttachmentManager.Insert(LectureAttachmentAddDto);
            return Ok("Created Successfully");


        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _lectureAttachmentManager.Delete(id);
            return NoContent();

        }
    }
}
