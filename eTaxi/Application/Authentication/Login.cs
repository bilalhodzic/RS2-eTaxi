using Model.Others;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {

        public async Task<SuccessLogin> Login(LoginModel model, bool isExternal = false)
        {
            if (model == null)
            {
                throw new UserException("Invalid client request");
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                user = await _userManager.FindByEmailAsync(model.UserName);

            if (!isExternal && !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new UserException(Messages.CredentialError);
            }

            if (user == null)
            {
                throw new UserException(Messages.CredentialError);
            }

            if (!user.EmailConfirmed)
            {
                //Logic for mobile app
                Random rnd = new Random();
                int pin = rnd.Next(1000, 9999);
                user.Pin = pin;
                var htmlCode = Authentication.GetMobileVerificationMessage(pin.ToString());
                var message = new EmailMessage(new string[] { user.Email }, "Verifikacija putem e-pošte ", htmlCode);
                _EmailService.SendEmail(message);
                _context.SaveChanges();
                //End of logic 
                throw new UserException(Messages.EmailVerification + $"[{user.Id}]");
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaim = new List<Claim> {
                        new Claim("Username",user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("PhoneNumberConfirmed", user.PhoneNumberConfirmed.ToString()),
                        new Claim(ClaimTypes.Name, model.UserName)
                    };
            foreach (var userRole in userRoles)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, userRole));
                authClaim.Add(new Claim("Role", userRole));
            }
            var accessToken = GenerateAccessToken(authClaim);
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            _context.SaveChanges();
            return new SuccessLogin { Token = accessToken, RefreshToken = refreshToken };
        }
    }
}

