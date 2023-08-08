using Microsoft.EntityFrameworkCore;

namespace ProductReviewSystemDemo.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Ratings { get; set; }
        public string? Comment { get; set; }
        public int ProductId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }  

    }
}
