using Domain;
using Microsoft.AspNetCore.WebUtilities;
using Model.Others;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<Response> CreateUser(ApplicationUser user, string Password, string userRoles, bool isWeb)
        {
            Random rnd = new Random();
            int pin = rnd.Next(1000, 9999);
            if (isWeb == false)
                user.Pin = pin;
            var result = await _userManager.CreateAsync(user, Password);
            if (await _roleManager.RoleExistsAsync(userRoles))
            {
                await _userManager.AddToRoleAsync(user, userRoles);
            }
            if (result.Succeeded)
            {
                File ProfileImage = new File();
                ProfileImage.Url = _appSettings.ImagesUrl + ImagesPath.DefaultProfileImage;
                ProfileImage.Type = Messages.ProfileImage;
                ProfileImage.FileName = ImagesPath.DefaultProfileImage;
                ProfileImage.OriginalName = ImagesPath.DefaultProfileImage;
                ProfileImage.UserId = user.Id;
                if (user.UserType == UserRoles.Owner || user.UserType == UserRoles.Worker) {
                    File HeaderImage = new File();
                    HeaderImage.Url = _appSettings.ImagesUrl + ImagesPath.DefaultHeaderImage;
                    HeaderImage.Type = Messages.HeaderImage;
                    HeaderImage.FileName = ImagesPath.DefaultHeaderImage;
                    HeaderImage.OriginalName = ImagesPath.DefaultHeaderImage;
                    HeaderImage.UserId = user.Id;
                    _context.Add(HeaderImage);
                }
                _context.Add(ProfileImage);
                _context.SaveChanges();
                if (isWeb == true)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    SendVerificationMail(token, user.Id, user.Email);
                }
                if (isWeb == false)
                {
                    SendMobileVerificationMail(user.Email, pin);
                }

                    _context.SaveChanges();
                
                    return new Response { Status = Messages.Success, Message = Messages.UserCreated, UserId = user.Id };
            }
            else
            {
                throw new UserException($"{Messages.InternalError}");
            }
        }

    }
}
