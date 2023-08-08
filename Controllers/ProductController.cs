using Microsoft.AspNetCore.Mvc;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services.Interfaces;

namespace ProductReviewSystemDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController( IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProductAll")]
        public async Task<ActionResult<Product>> GetAllProductsAsync()
        {
            var result = _productService.GetAllProductsAsync();
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int ProductId)
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
            return Ok();
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProductAsync(int ProductId)
        {
            var result = _productService.UpdateProductAsync(ProductId);
            if (result == null)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("DeleteProduct")]
        public async Task <ActionResult> DeleteProductAsync(int ProductId)
        {
            var result = _productService.DeleteProductAsync(ProductId);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
       
    }
}
