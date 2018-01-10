using PhotoTrip.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PhotoTrip.Infrastructure.ViewModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using PhotoTrip.Infrastructure.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace PhotoTrip.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        public JwtDto CreateToken(string email,string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.UniqueName, email),
                new Claim(ClaimTypes.Role,role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(5);
            var signingCredenctials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jwt-secret-password")),SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(issuer: "http://localhost:53826",
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredenctials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            var result = new JwtDto
            {
                Token = token,
                Expiry = expires.ToTimestamp()
            };
            return result;
        }
    }
}
