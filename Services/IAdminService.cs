using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.Services
{
    public interface IAdminService
    {
        Task<Product> AddProductAsync(Product product);
        Task<Product> GetAllProductsAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<List<Review>> GetAllFeedbacksAsync();
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(Product ProductId);

    }
}
