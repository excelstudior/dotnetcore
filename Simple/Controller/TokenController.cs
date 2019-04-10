using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Simple.Controller
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Main
        public IActionResult CreateToken([FromBody] LoginModel login)
        {
            
            IActionResult response = Unauthorized();

            //step 1 authenticated
            var user = Authenticated(login);
            //step 2 generate a token if the user legit

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token=tokenString});
            }
            return response;
        }

        private string BuildToken(UserModel user)
        {
            //create an array of claims, https://tools.ietf.org/html/rfc7519#section-4
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub,user.Name),
               new Claim(JwtRegisteredClaimNames.Email,user.Email),
               new Claim(JwtRegisteredClaimNames.Birthdate,user.Birthdate.ToString("yyyy-MM-dd")),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            // generate keys and credentials

            var configuration = _configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            //create JWT token
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                             _configuration["Jwt:Issuer"],
                                             claims, 
                                             expires: DateTime.Now.AddMinutes(60),
                                             signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticated(LoginModel login)
        {
            UserModel user = null;
            //connect to database to verify passwords
            if (login.Username=="mario" && login.Password == "secret")
            {
                user = new UserModel
                {
                    Name = "mario",
                    Email = "secret@gmail.com",
                    Birthdate=DateTime.Now
                };
            }

            return user;
        }
    }

    internal class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}