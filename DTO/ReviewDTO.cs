namespace ProductReviewSystemDemo.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Ratings { get; set; }
        public string? Comment { get; set; }
    }
}
