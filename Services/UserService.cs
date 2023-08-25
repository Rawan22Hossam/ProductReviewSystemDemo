using ProductReviewSystemDemo.DTO;
using ProductReviewSystemDemo.GenericRepository;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services.Interfaces;
using ProductReviewSystemDemo.Helper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Models;
using Microsoft.AspNetCore.DataProtection;
using ProductReviewSystemDemo.UnitOfWork;

namespace ProductReviewSystemDemo.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> userRepository, IConfiguration configuration,IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
           
        }
        public async Task<BaseError<string>> Register(UserDTO user)
        { 
            // map userdto to new entity of user with auto mapper
            var AllUsers = _mapper.Map<User>(user);
            var userdb = _userRepository.GetAll(a => a.Role).FirstOrDefault(a => a.UserName == user.UserName);
            if (userdb != null)
                return new BaseError<string>() { ErrorCode = (int)ErrorsEnum.UserAllReadyRegistered, ErrorMessage = ErrorsEnum.UserAllReadyRegistered.ToString() };
           
            AllUsers.PasswordHash= HelperClass.CreatePasswordHash(user.Password);
            var userAdd = _userRepository.Add(AllUsers);
            _userRepository.SaveChanges();
            return new BaseError<string>() { ErrorCode = (int)ErrorsEnum.Success, ErrorMessage = ErrorsEnum.Success.ToString() };

        }
        public async Task<BaseError<string>> Login(UserDTO user)
        {
            var passwordhash = HelperClass.CreatePasswordHash(user.Password);
            var userdb = _userRepository.GetAll(a => a.Role).FirstOrDefault(a => a.UserName == user.UserName && a.PasswordHash == passwordhash);
            if (userdb == null)
                return new BaseError<string>() { ErrorCode = (int)ErrorsEnum.InvalidUsernameOrPassword,ErrorMessage = ErrorsEnum.InvalidUsernameOrPassword.ToString() };
            var secret = _configuration.GetSection("Token:secretKey").Value;

            var token = HelperClass.CreateToken(userdb, secret);

            return new BaseError<string>()
            {
                ErrorCode = (int)ErrorsEnum.Success,
                ErrorMessage = ErrorsEnum.Success.ToString(),
                Data = token
            };
        }
        public async Task<IQueryable<User>> GetAllUsersAsync()
        {
            var users = _userRepository.GetAll();
            return users;
        }
        public async Task<User> GetUserById(int UserId)
        {
            return await _userRepository.GetById(UserId);
        }
        public async Task UpdateUser(User UserId)
        {
            await _userRepository.Update(UserId);
        }
        public async Task DeleteUser(User UserId)
        {
            await _userRepository.Delete(UserId);
        }
       
    }
}

