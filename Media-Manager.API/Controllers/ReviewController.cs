using Media_Manager.Core.Converters;
using Media_Manager.Core.DTOs;
using MediaManager.Core.Interfaces;
using MediaManager.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Media_Manager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repository;

        public ReviewController(IReviewRepository repository)
        {
            _repository = repository;    
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Review>>> GetReviews()
        {
            var reviews = await _repository.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
         public async Task<ActionResult<Review>> GetReviewById(int reviewId)
        {
            var review = await _repository.GetByIdAsync(reviewId);
            if (review == null)
            {
                return NotFound($"The review with id {reviewId} was not found");
            }
            return Ok(review);
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var deleted = await _repository.DeleteAsync(reviewId);
            if(!deleted)
            {
                return NotFound($"review with id {reviewId} was not found");
            }
            return NoContent();
        }

        [HttpPut("{reviewId}")]
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] UpdateReviewDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateReview = dto.FromUpdateReviewDto();
            updateReview.Id = reviewId;
            return Ok(updateReview);

        }

    }
}
