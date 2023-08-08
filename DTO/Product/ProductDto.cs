using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.DTO.Product
{
    public class ProductDto
    {
        int ProductId { get; set; } 
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }
       

    }
}
