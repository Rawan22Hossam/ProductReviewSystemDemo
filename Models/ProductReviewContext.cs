using Microsoft.EntityFrameworkCore;

namespace ProductReviewSystemDemo.Models
{
    public class ProductReviewContext : DbContext
    {
        protected ProductReviewContext(DbContextOptions<ProductReviewContext> options) : base(options)
        {

        }
        public DbSet<Product> product { get; set; }
        public DbSet<Review> review { get; set; }
        public DbSet<User> user { get; set; }

    }
}
