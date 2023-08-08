using Microsoft.AspNetCore.Mvc;
using ProductReviewSystemDemo.DTO;
using ProductReviewSystemDemo.Models;

namespace ProductReviewSystemDemo.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseError<string>> Register(UserDTO request);
        Task<BaseError<string>> Login(UserDTO user);
        Task<IQueryable<User>> GetAllUsersAsync();
        Task<User> GetUserById(int UserId);
        Task UpdateUser(User UserId);
        Task DeleteUser(User UserId);
    }
}
