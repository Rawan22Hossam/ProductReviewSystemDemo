using Microsoft.AspNetCore.Http.HttpResults;
using ProductReviewSystemDemo.GenericRepository;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services.Interfaces;

namespace ProductReviewSystemDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepo;
        public ProductService(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IQueryable<Product>> GetAllProductsAsync()
        {
            var product =  _productRepo.GetAll();
            return product;
        }
       
        public async Task<Product> GetProductById(int ProductId)
        {
            return await _productRepo.GetById(ProductId);
        }
        public async Task AddProductAsync(Product product)
        {
            await _productRepo.Add(product);
        }
        public async Task UpdateProductAsync(int ProductId) 
        {
            await _productRepo.Update(ProductId);
        }
        public async Task DeleteProductAsync(int ProductId) 
        {
            await _productRepo.Delete(ProductId);
        }
    }
}
