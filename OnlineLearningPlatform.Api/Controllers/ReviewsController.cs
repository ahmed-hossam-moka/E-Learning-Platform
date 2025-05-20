using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Managers;
using OnlineLearningPlatform.DAL.Repository;
using OnlineLearningPlatform.DAL;
using OnlineLearningPlatform.BLL.Dtos.Reviews;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewManager _reviewManager;

        public ReviewsController(IReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        // GET: api/reviews/course/{courseId}
        [HttpGet("course/{courseId}")]
        public IActionResult GetReviewsByCourse(int courseId)
        {
            var reviews = _reviewManager.GetAll()
                .Where(r => r.CourseId == courseId);
            return Ok(reviews);
        }

        // GET: api/reviews/{id}
        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            var review = _reviewManager.GetById(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        // POST: api/reviews
        [HttpPost]
        public IActionResult AddReview([FromBody] ReviewAddDto reviewDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _reviewManager.Add(reviewDto);
            return CreatedAtAction(nameof(GetReview), new { id = reviewDto.ReviewId }, reviewDto);
        }

        // PUT: api/reviews/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateReview(int id, [FromBody] ReviewUpdateDto reviewDto)
        {
            if (id != reviewDto.ReviewId) return BadRequest("ID mismatch");

            _reviewManager.Update(reviewDto);
            return NoContent();
        }

        // DELETE: api/reviews/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            _reviewManager.Delete(id);
            return NoContent();
        }
    }
}

