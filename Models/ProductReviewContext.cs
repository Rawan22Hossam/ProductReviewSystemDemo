using Microsoft.EntityFrameworkCore;

namespace ProductReviewSystemDemo.Models
{
    public class ProductReviewContext : DbContext
    {
        public ProductReviewContext(DbContextOptions<ProductReviewContext> options) : base(options)
        {

        }
        public DbSet<Product> product { get; set; }
        public DbSet<Review> review { get; set; }
        public DbSet<User> user { get; set; }

        internal Task<Product> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        internal Task<Product> DeleteProductAsync(Product productId)
        {
            throw new NotImplementedException();
        }

        internal Task<Review> Feedback(string comments)
        {
            throw new NotImplementedException();
        }

        internal Task<List<Review>> GetAllFeedbacksAsync()
        {
            throw new NotImplementedException();
        }

        internal Task<Product> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        internal Task<List<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        internal Task<User> Login(User user)
        {
            throw new NotImplementedException();
        }

        internal Task<Review> Rating(int userId)
        {
            throw new NotImplementedException();
        }

        internal Task<User> Registeration(User user)
        {
            throw new NotImplementedException();
        }

        internal Task<User> UpdateDetails(User user)
        {
            throw new NotImplementedException();
        }

        internal Task<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        internal Task<Product> ViewCategory(string productCategory)
        {
            throw new NotImplementedException();
        }

        internal Task<Product> ViewProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
