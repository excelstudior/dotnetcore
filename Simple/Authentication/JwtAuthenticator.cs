using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Simple.Entity;
using Simple.Entity.Access;

namespace Simple.Authentication
{
    public class JwtAuthenticator
    {
        private IConfiguration _configuration;
        public JwtAuthenticator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public User Authenticated(LogInModel logInModel)
        {
            User user = null;

            //connect to database to get password

            return user;
        }
        public string BuildToken(User user)
        {
            if (user == null) { return "Invalid user or password"; }
            //create an array of claims, https://tools.ietf.org/html/rfc7519#section-4
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub,user.Name),
               new Claim(JwtRegisteredClaimNames.Email,user.Email),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            // generate keys and credentials

            var configuration = _configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //create JWT token
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                             _configuration["Jwt:Issuer"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(60),
                                             signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
