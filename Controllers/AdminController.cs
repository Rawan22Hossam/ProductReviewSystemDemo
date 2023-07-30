using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services;
namespace ProductReviewSystemDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        //private readonly IAdminService _adminService;
        private readonly ProductReviewContext _dbcontext;
        public AdminController(ProductReviewContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        /*public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        */
        [HttpGet("Add New Product")]
        public Task<Product> AddProductAsync(Product product)
        {
            return _dbcontext.AddProductAsync(product);
        }
        [HttpGet("Get All Products")]
        public Task<Product> GetAllProductsAsync()
        {
            return _dbcontext.GetAllProductsAsync();
        }
        [HttpGet("Get All User")]
        public Task<List<User>> GetAllUsersAsync()
        {
            return _dbcontext.GetAllUsersAsync();
        }
        [HttpGet("Get All Feedbacks")]
        public Task<List<Review>> GetAllFeedbacksAsync()
        {
            return _dbcontext.GetAllFeedbacksAsync();
        }
        [HttpPut("Update Product")]
        public Task<Product> UpdateProductAsync(Product product)
        {
            return _dbcontext.UpdateProductAsync(product);
        }
        [HttpDelete("Delete Product")]
        public Task<Product> DeleteProductAsync(Product ProductId)
        {
            return _dbcontext.DeleteProductAsync(ProductId);
        }
    }
}
