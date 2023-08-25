using ProductReviewSystemDemo.DTO;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IQueryable<ReviewDTO>> GetAllReviewsAsync();
        Task<Review> GetReviewById(ReviewDTO reviewDTO);
        Task AddReviewAsync(Review reviewDTO);
        Task UpdateReviewAsync(ReviewDTO reviewDTO);
        Task DeleteReviewAsync(ReviewDTO reviewDTO);
    }
}
