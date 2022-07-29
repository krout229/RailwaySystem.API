using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RailwaySystem.API.Models;
using RailwaySystem.API.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RailwaySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserS _userServices;
        public UserController(UserS userServices)
        {
            _userServices = userServices;
        }
        [HttpPost("SaveUser")]
        public IActionResult SaveUser(User user)
        {
            return Ok(_userServices.SaveUser(user));
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            return Ok(_userServices.UpdateUser(user));
        }
        [HttpGet("GetUser")]
        public IActionResult GetUser(int UserId)
        {
            return Ok(_userServices.GetUser(UserId));
        }
        [HttpGet("GetUserByEmail")]
        public IActionResult GetUserByEmail(string Email)
        {
            return Ok(_userServices.GetUserByEmail(Email));
        }
        [HttpGet("GetAllUser()")]
        public List<User> GetAllUser()
        {
            return _userServices.GetAllUser();
        }

        #region LoginModel

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = _userServices.GetUserByEmail(model.Email);
            if (user != null && model.Password == user.Password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.UserId.ToString(), "Email", user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("55f6UmNJfrbdi8It")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Email or Password is incorrect." });
            }
            #endregion
        }
    }
}
