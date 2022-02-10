using Microsoft.IdentityModel.Tokens;
using Model.Others;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public partial class JwtGenerator
    {
        public string GenerateToken(LoginModel model,int id,bool VerifiedAccount)
        {
            var authClaim = new List<Claim> {
                        new Claim("Username",model.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim("UserId", id.ToString()),
                        new Claim("VerifiedAccount", VerifiedAccount.ToString()),
                    };
            authClaim.Add(new Claim("Role", UserRoles.User));
            var authSinginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                      issuer: _configuration["JWT:ValidIssuer"],
                      audience: _configuration["JWT:ValidAudience"],
                      expires: DateTime.Now.AddHours(5),
                      claims: authClaim,
                      signingCredentials: new SigningCredentials(authSinginKey, SecurityAlgorithms.HmacSha256Signature));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
