using Microsoft.AspNetCore.Identity;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }    
        public string Password { get; set; }  
        public int RoleId { get; set; } 
    }
}
