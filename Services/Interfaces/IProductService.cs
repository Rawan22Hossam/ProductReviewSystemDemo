using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.Services.Interfaces
{
    public interface IProductService
    {
        Task<IQueryable<Product>> GetAllProductsAsync();
        Task<Product> GetProductById(int ProductId);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(int ProductId);
        Task DeleteProductAsync(int ProductId);
        
    }
}
