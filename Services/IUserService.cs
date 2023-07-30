using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.Services
{
    public interface IUserService
    {
        Task<Review> Feedback(string comments);
        Task<User> Login(User user);
        Task<Review> Rating(int userId);
        Task<User> Registeration(User user);
        Task<User> UpdateDetails(User user);
        Task<Product> ViewCategory(string productCategory);
        Task<Product> ViewProduct(Product product);
    }
}
