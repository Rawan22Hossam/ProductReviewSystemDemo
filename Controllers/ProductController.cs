using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductReviewSystemDemo.GlobalExceptionHandler;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services.Interfaces;
using Serilog;

namespace ProductReviewSystemDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController( IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProductAll")]
        [Authorize]
        public async Task<ActionResult> GetAllProductsAsync()
        {
           
                var result = _productService.GetAllProductsAsync();
                if (result == null)
                    return BadRequest();
                Log.Information("All Users => {@result}", result);
                return Ok(result);
        }

        [HttpGet("GetProductById")]
        
        public async Task<ActionResult> GetProductById(int ProductId)
        {
            var result = _productService.GetProductById(ProductId);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProductAsync(Product product)
        {
            var result = _productService.AddProductAsync(product);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProductAsync(int ProductId)
        {
            var result = _productService.UpdateProductAsync(ProductId);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult> DeleteProductAsync(int ProductId)
        {
            var result = _productService.DeleteProductAsync(ProductId);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
       
    }
}
