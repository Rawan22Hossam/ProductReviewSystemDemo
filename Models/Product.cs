namespace ProductReviewSystemDemo.Models
{
    public class Product
    {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public List<Review> Review { get; set; } = new List<Review>();
            public int ProductPrice { get; set; }
            public string ProductCategory { get; set; } = " ";
        //  public string? ProductCategory {get; set;}
        
    }
}
