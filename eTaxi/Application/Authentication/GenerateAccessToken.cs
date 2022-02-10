using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {

            var authSinginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
               issuer: _configuration["JWT:ValidIssuer"],
               audience: _configuration["JWT:ValidAudience"],
               expires: DateTime.Now.AddHours(5),
               claims: claims,
               signingCredentials: new SigningCredentials(authSinginKey, SecurityAlgorithms.HmacSha256Signature));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static string GetHmacSha256()
        {
            return SecurityAlgorithms.HmacSha256;
        }
    }
}
