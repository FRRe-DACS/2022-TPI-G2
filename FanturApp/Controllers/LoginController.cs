using FanturApp.Business.Interfaces;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FanturApp.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IUserBusiness _userBusiness;
    

        public LoginController(IConfiguration config, IUserBusiness userBusiness)
        {
            _config = config;
            _userBusiness = userBusiness;
        }

     

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var logeduserinfo = new LogedUserInfoDto();
                logeduserinfo.Token = Generate(user);
                logeduserinfo.FirstName = user.FirstName;
                logeduserinfo.LastName = user.LastName;
                logeduserinfo.Email = user.Email;
                logeduserinfo.Role = user.Role;
                logeduserinfo.UserId = user.Id;
                return Ok(logeduserinfo);
            }

            return NotFound("User not found");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.HomePhone, user.PhoneNumber),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserLogin userLogin)
        {
            var currentUser = _userBusiness.GetUserByUsernameAndPassword(userLogin.UserName, userLogin.PassWord);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}
