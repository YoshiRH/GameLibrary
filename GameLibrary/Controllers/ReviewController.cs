using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameLibrary.Api.Dtos;
using GameLibrary.Api.Entities;
using GameLibrary.Api.Services;

namespace GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(IReviewService reviewService, IGameService gameService) : ControllerBase
    {
        private readonly IReviewService _reviewService = reviewService;
        private readonly IGameService _gameService = gameService;

        [HttpGet("review/{id}")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);

            if (review is null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpPost("createReview")]
        public async Task<ActionResult> AddReview(ReviewCreateDto review)
        {
            if(review == null)
            {
                return BadRequest();
            }

            await _reviewService.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetReviewById), new { id = review }, review);
        }

        [HttpDelete("deleteReview/{reviewId}")]
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            var review = await _reviewService.GetReviewByIdAsync(reviewId);

            if(review is null)
            {
                return NotFound();
            }

            await _reviewService.DeleteReviewAsync(reviewId);
            return NoContent();
        }
    }
}
