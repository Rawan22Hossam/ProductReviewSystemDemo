namespace ProductReviewSystemDemo.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public int ProductId { get; set; }
        public int ReviewId { get; set; }
        public Roles Role { get; set; }
        public ICollection<Review> Reviews { get; set; }

        // public ICollection<Product> Product { get; set; }
        // 
    }
}
