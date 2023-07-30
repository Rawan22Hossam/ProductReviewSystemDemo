using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services;
namespace ProductReviewSystemDemo.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminService _adminService;
        public AdminService(IAdminService adminService) {
            adminService = _adminService;
        }   
        public Task<Product> AddProductAsync(Product product)
        {
            return _adminService.AddProductAsync(product);
        }

        public Task<Product> GetAllProductsAsync()
        {
            return _adminService.GetAllProductsAsync();
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return _adminService.GetAllUsersAsync();
        }

        public Task<List<Review>> GetAllFeedbacksAsync()
        {
            return _adminService.GetAllFeedbacksAsync();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            return _adminService.UpdateProductAsync(product);
        }

        public Task<Product> DeleteProductAsync(Product ProductId)
        {
            return _adminService.DeleteProductAsync(ProductId);
        }
    }
}
