namespace ProductReviewSystemDemo.Models
{
    public class Review
    {

        public int Ratings { get; set; }
        public int UserId { get; set; }
        public List<Review> Comments { get; set; } = new List<Review>();
    }
}
