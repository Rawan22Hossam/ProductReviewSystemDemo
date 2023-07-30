using ProductReviewSystemDemo.Models;
namespace ProductReviewSystemDemo.Services
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        public UserService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<User> Registeration(User user) 
        {
            return await _userService.Registeration(user);        
        }
        public async Task<User> Login(User user)
        {
            return await _userService.Login(user);
        }
        public async Task<Product> ViewCategory(string ProductCategory)
        {
            return await _userService.ViewCategory(ProductCategory);
        }
        public async Task<Product> ViewProduct(Product product)
        {
            return await _userService.ViewProduct(product);
        }
        public async Task<Review> Rating(int UserId)
        {
            return await _userService.Rating(UserId);
        }
        public async Task<Review> Feedback(string Comments)
        {
            return await _userService.Feedback(Comments);
        }
        public async Task<User> UpdateDetails(User user)
        {
            return await _userService.UpdateDetails(user);
        }
    }
}
