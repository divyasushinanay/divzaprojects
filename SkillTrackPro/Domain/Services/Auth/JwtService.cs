using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Auth
{
    //public class JwtService : IJwtService
    //   {
    //       private readonly IConfiguration _config;

    //       public JwtService(IConfiguration config)
    //       {
    //           _config = config;
    //       }

    //       public string GenerateToken(Guid id, string name, string email, string role)
    //       {
    //           var claims = new[]
    //           {
    //               new Claim("id", id.ToString()),
    //               new Claim("name", name),
    //               new Claim("email", email),
    //               new Claim(ClaimTypes.Role, role)
    //           };

    //           // FIXED: Correct section name
    //           var key = new SymmetricSecurityKey(
    //               Encoding.UTF8.GetBytes(_config["Jwt:Key"])
    //           );

    //           var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //           var token = new JwtSecurityToken(
    //               issuer: _config["Jwt:Issuer"],
    //               audience: _config["Jwt:Audience"],
    //               claims: claims,
    //               expires: DateTime.Now.AddHours(5),
    //               signingCredentials: creds
    //           );

    //           return new JwtSecurityTokenHandler().WriteToken(token);
    //       }

    //       public string GenerateToken(Guid id, string email, string v)
    //       {
    //           throw new NotImplementedException();
    //       }
    //   }

    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(Guid id, string name, string email, string role)
        {
            var claims = new List<Claim>
            {
                // 🔑 VERY IMPORTANT (Used to get CoachId)
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),

                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateToken(Guid id, string email, string v)
        {
            throw new NotImplementedException();
        }
    }
}
