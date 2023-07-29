namespace ProductReviewSystemDemo.Models
{
    public class User
    {

        public string UserName { get; set; }
        public int UserId { get; set; }
        public List<Product> Product { get; set; } = new List<Product>();
        public List<Review> Review { get; set; } = new List<Review>();
    }
}
