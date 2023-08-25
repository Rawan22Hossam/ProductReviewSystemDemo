using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductReviewSystemDemo.DTO;
using ProductReviewSystemDemo.GlobalExceptionHandler;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services.Interfaces;
using Serilog;

namespace ProductReviewSystemDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("GetAllReviews")]
        public async Task<ActionResult> GetAllReviewsAsync()
        {

            var result = _reviewService.GetAllReviewsAsync();
            if (result == null)
                return BadRequest();
            Log.Information("All Reviews => {@result}", result);
            return Ok(result);
        }

       [HttpGet("GetReviewById")]
        [Authorize]
        public async Task<ActionResult> GetReviewById(ReviewDTO reviewDTO)
        {
            var result = _reviewService.GetReviewById(reviewDTO);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost("AddReview")]
        [Authorize("Client")]
        public async Task<ActionResult> AddReviewAsync(Review reviewDTO)
        {
            var result = _reviewService.AddReviewAsync(reviewDTO);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("UpdateReview")]
        [Authorize("Admin")]
        public async Task<ActionResult> UpdateReviewAsync(ReviewDTO reviewDTO)
        {
            var result = _reviewService.UpdateReviewAsync(reviewDTO);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("DeleteReview")]
        [Authorize("Admin  ")]
        public async Task<ActionResult> DeleteReviewAsync(ReviewDTO reviewDTO)
        {
            var result = _reviewService.DeleteReviewAsync(reviewDTO);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
       
    }
}
