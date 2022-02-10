using Application.Authentication;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Others;
using Persistence;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public partial class JwtGenerator : IJwtGenerator
    {
        protected readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly eTaxiDbContext _context;

        private readonly IEmail _EmailService;

        public JwtGenerator(IConfiguration configuration, UserManager<ApplicationUser> userManager, eTaxiDbContext context, IEmail EmailService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _EmailService = EmailService;
            _context = context;
               
        }
        //public async Task<string> CreateToken(LoginModel model)
        //{
        //    var user = await _userManager.FindByNameAsync(model.UserName);
        //    if (user == null)
        //        user = await _userManager.FindByEmailAsync(model.UserName);

        //    if (user != null)
        //    {
        //        if (!user.EmailConfirmed)
        //        {
        //            //Logic for mobile app
        //            Random rnd = new Random();
        //            int pin = rnd.Next(1000, 9999);
        //            user.Pin = pin;
        //            var htmlCode = Authentication.GetMobileVerificationMessage(pin.ToString());
        //            var message = new EmailMessage(new string[] { user.Email }, "Verifikacija putem e-pošte ", htmlCode);
        //            _EmailService.SendEmail(message);
        //            _context.SaveChanges();
        //            //End of logic 
        //            throw new UserException(Messages.EmailVerification + $"[{user.Id}]");
        //        }

        //        if (await _userManager.CheckPasswordAsync(user, model.Password))
        //        {
        //            var userRoles = await _userManager.GetRolesAsync(user);
        //            var authClaim = new List<Claim> {
        //                new Claim("Username",user.UserName),
        //                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //                new Claim("UserId", user.Id.ToString()),
        //            };
        //            foreach (var userRole in userRoles)
        //            {
        //                authClaim.Add(new Claim(ClaimTypes.Role, userRole));
        //                authClaim.Add(new Claim("Role", userRole));
        //            }
        //            var authSinginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        //            var token = new JwtSecurityToken(
        //               issuer: _configuration["JWT:ValidIssuer"],
        //               audience: _configuration["JWT:ValidAudience"],
        //               expires: DateTime.Now.AddHours(5),
        //               claims: authClaim,
        //               signingCredentials: new SigningCredentials(authSinginKey, SecurityAlgorithms.HmacSha256Signature));
        //            return new JwtSecurityTokenHandler().WriteToken(token);
        //        }
        //    }
        //    throw new UserException(Messages.CredentialError);
        //}

    }

}

