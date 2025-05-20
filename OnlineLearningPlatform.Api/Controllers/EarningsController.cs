using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos.Earnings;
using OnlineLearningPlatform.BLL.Managers;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningsController : ControllerBase
    {
        private readonly IEarningsManager _earningsManager;

        public EarningsController(IEarningsManager earningsManager)
        {
            _earningsManager = earningsManager;
        }

        // GET: api/instructors/{instructorId}/earnings
        [HttpGet]
        public IActionResult GetEarnings(string instructorId)
        {
            var earnings = _earningsManager.GetAll().Where(e => e.InstructorId == instructorId);
            return Ok(earnings);
        }

        // POST: api/instructors/{instructorId}/earnings
        [HttpPost]
        public IActionResult AddEarning(string instructorId, [FromBody] EarningsAddDto earningDto)
        {
            if (instructorId != earningDto.InstructorId)
                return BadRequest("Instructor ID mismatch");

            _earningsManager.Add(earningDto);
            return CreatedAtAction(nameof(GetEarnings), new { instructorId }, earningDto);
        }

        // PUT: api/instructors/{instructorId}/earnings/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEarningStatus(int id, [FromBody] EarningsUpdateDto earningDto)
        {
            if (id != earningDto.EarningId) return BadRequest("ID mismatch");

            _earningsManager.Update(earningDto);
            return NoContent();
        }
    }
}
