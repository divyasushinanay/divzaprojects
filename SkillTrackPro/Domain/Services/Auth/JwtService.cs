using Domain.Enum;
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
    //{
    //    private readonly IConfiguration _config;

    //    public JwtService(IConfiguration config)
    //    {
    //        _config = config;
    //    }

    //    public string GenerateToken(Guid id, string name, string email, string role)
    //    {
    //        var claims = new[]
    //        {
    //            // 🔑 VERY IMPORTANT
    //            new Claim(ClaimTypes.NameIdentifier, id.ToString()),

    //            new Claim(ClaimTypes.Name, name),
    //            new Claim(ClaimTypes.Email, email),

    //            // 🔐 Role-based authorization
    //            new Claim(ClaimTypes.Role, role)
    //        };

    //        var key = new SymmetricSecurityKey(
    //            Encoding.UTF8.GetBytes(_config["Jwt:Key"])
    //        );

    //        var creds = new SigningCredentials(
    //            key,
    //            SecurityAlgorithms.HmacSha256
    //        );

    //        var token = new JwtSecurityToken(
    //            issuer: _config["Jwt:Issuer"],
    //            audience: _config["Jwt:Audience"],
    //            claims: claims,
    //            expires: DateTime.UtcNow.AddHours(5),
    //            signingCredentials: creds
    //        );

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }

    //    public string GenerateAcademyToken(int id, string username, string? email, Role role)
    //    {
    //        var claims = new[]
    //        {
    //        new Claim(ClaimTypes.NameIdentifier, id.ToString()),
    //        new Claim(ClaimTypes.Name, username),
    //        new Claim(ClaimTypes.Email, email ?? ""),
    //        new Claim(ClaimTypes.Role, role.ToString()) // ✅ Convert enum to string
    //    };

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken(
    //            issuer: _config["Jwt:Issuer"],
    //            audience: _config["Jwt:Audience"],
    //            claims: claims,
    //            expires: DateTime.UtcNow.AddHours(5),
    //            signingCredentials: creds
    //        );

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }
    //}

    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(Guid id, string name, string email, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            return GenerateJwt(claims);
        }

        public string GenerateAcademyToken(Guid id, string username, string email, Role role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim("username", username),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            return GenerateJwt(claims);
        }

        private string GenerateJwt(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
