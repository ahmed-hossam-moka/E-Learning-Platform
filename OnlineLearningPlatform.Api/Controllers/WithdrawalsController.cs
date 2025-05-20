using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos.Withdrawal;
using OnlineLearningPlatform.BLL.Managers;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawalsController : ControllerBase
    {
        private readonly IWithdrawalManager _withdrawalManager;

        public WithdrawalsController(IWithdrawalManager withdrawalManager)
        {
            _withdrawalManager = withdrawalManager;
        }

        // GET: api/instructors/{instructorId}/withdrawals
        [HttpGet]
        public IActionResult GetWithdrawals(string instructorId)
        {
            var withdrawals = _withdrawalManager.GetAll().Where(w => w.InstructorId == instructorId);
            return Ok(withdrawals);
        }

        // POST: api/instructors/{instructorId}/withdrawals
        [HttpPost]
        public IActionResult RequestWithdrawal(string instructorId, [FromBody] WithdrawalAddDto withdrawalDto)
        {
            if (instructorId != withdrawalDto.InstructorId)
                return BadRequest("Instructor ID mismatch");

            _withdrawalManager.Add(withdrawalDto);
            return CreatedAtAction(nameof(GetWithdrawals), new { instructorId }, withdrawalDto);
        }

        // PUT: api/instructors/{instructorId}/withdrawals/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateWithdrawalStatus(int id, [FromBody] WithdrawalUpdateDto withdrawalDto)
        {
            if (id != withdrawalDto.WithdrawalId) return BadRequest("ID mismatch");

            _withdrawalManager.Update(withdrawalDto);
            return NoContent();
        }
    }
}
