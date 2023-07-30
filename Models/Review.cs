using Microsoft.EntityFrameworkCore;

namespace ProductReviewSystemDemo.Models
{
    public class Review
    {
        public int Id { get; set; } 
        public int Ratings { get; set; }
        public int UserId { get; set; }
        public List<Review> Comments { get; set; } = new List<Review>();
    }
}
