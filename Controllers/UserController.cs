﻿using Microsoft.AspNetCore.Mvc;
using ProductReviewSystemDemo.DTO;
using ProductReviewSystemDemo.Models;
using ProductReviewSystemDemo.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Serilog;

namespace ProductReviewSystemDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
       
        private readonly IUserService _userService;
      
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        
        public async Task<ActionResult<BaseError<string>>> Register(UserDTO user)
        {
            var res = await _userService.Register(user);
            if (res.ErrorCode == (int)ErrorsEnum.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
            
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDTO user)
        {
            var res = await _userService.Login(user);
            if(res.ErrorCode==(int)ErrorsEnum.Success)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsersAsync()
        {
            if (User.IsInRole("Admin"))
            {
                var result = _userService.GetAllUsersAsync();
                if (result == null)
                    return BadRequest();
                Log.Information("All Users => {@result}");
                return Ok(result);
            }
            else 
                return Unauthorized();
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult> GetUserById(int UserId)
        {
            var result = _userService.GetUserById(UserId);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(User UserId)
        {
            var result = _userService.UpdateUser(UserId);
            if (result == null)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(User UserId)
        {
            var result = _userService.DeleteUser(UserId);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }  
    }

}

