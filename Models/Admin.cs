
namespace ProductReviewSystemDemo.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public int RoleId { get; set; } = 3;

    }
}
