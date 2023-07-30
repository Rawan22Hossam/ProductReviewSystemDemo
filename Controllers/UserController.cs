using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services;
namespace ProductReviewSystemDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IUserService _userService;
        private readonly ProductReviewContext _dbcontext;
        public UserController(ProductReviewContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        /*public UserController(IUserService userService)
       {
           _userService = userService;
       }
*/
        [HttpGet("Registeration")]
        public async Task<User> Registeration(User user)
        {
            return await _dbcontext.Registeration(user);
        }
        [HttpPost("Login")]
        public async Task<User> Login(User user)
        {
            //if (user == null) 
            //    return NotFound(); 
            return await _dbcontext.Login(user);
        }
        [HttpGet("ProductCategory")]
        public async Task<Product> ViewCategory(string ProductCategory)
        {
            return await _dbcontext.ViewCategory(ProductCategory);
        }
        [HttpGet("View Product")]
        public async Task<Product> ViewProduct(Product product)
        {
            return await _dbcontext.ViewProduct(product);
        }
        [HttpGet("Rating")]
        public async Task<Review> Rating(int UserId)
        {
            return await _dbcontext.Rating(UserId);
        }
        [HttpGet("Feedback")]
        public async Task<Review> Feedback(string Comments)
        {
            return await _dbcontext.Feedback(Comments);
        }
        [HttpPut("Update Details")]
        public async Task<User> UpdateDetails(User user)
        {
            return await _dbcontext.UpdateDetails(user);
        }
    }
}
