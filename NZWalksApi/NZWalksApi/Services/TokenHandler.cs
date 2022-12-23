using Microsoft.IdentityModel.Tokens;
using NZWalksApi.Models;
using NZWalksApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalksApi.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            //Create Claims
            var claims = new List<Claim>();
            claims.AddRange(new List<Claim> {
            new Claim(ClaimTypes.GivenName,user.FirstName),
            new Claim(ClaimTypes.Surname,user.LastName),
            new Claim(ClaimTypes.Email,user.Email)
            });

            //user.Roles.ForEach(role =>
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //});

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
