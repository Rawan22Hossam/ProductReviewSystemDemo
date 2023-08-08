namespace ProductReviewSystemDemo.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientPassword { get; set; }
        public Roles Role { get; set; }
        public int RoleId { get; set; } = 2;

    }
}
