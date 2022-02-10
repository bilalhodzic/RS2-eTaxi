using Microsoft.AspNetCore.WebUtilities;
using Model.Others;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<Response> ForgotPassword(ForgotPassword model)
        {
            if (model.IsMobile != true)
                model.IsMobile = false;

            var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    throw new UserException("Ne postoji korisnik sa navedenom email adresom.");
            if (model.IsMobile==false)
            {

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var queryParams = new Dictionary<string, string>()
                {
                    {"token", token },
                    {"email", model.Email }
                };

                var url = _appSettings.AppUrl;
                var resource = "/resetpassword";
                var confLink = QueryHelpers.AddQueryString(resource, queryParams);

                confLink = url + confLink;

                var link = GetForgotPasswordMessage(confLink);
                var message = new EmailMessage(new string[] { model.Email }, "Poništavanje lozinke", link);
                _EmailService.SendEmail(message);
            }
            else if (model.IsMobile==true) {
                Random rnd = new Random();
                int pin = rnd.Next(1000, 9999);
                var User = await _userManager.FindByEmailAsync(model.Email);
                User.Pin = pin;
                await _userManager.UpdateAsync(User);
                var htmlCode = GetMobileForgotPasswordMessage(pin.ToString());
                var message = new EmailMessage(new string[] { model.Email }, "Poništavanje lozinke", htmlCode);
                _EmailService.SendEmail(message);
            }

                return new Response { Status = Messages.Success, Message = "Poruka za poništavanje lozinke uspješno je poslan na email", UserId=user.Id };
            
        }
    }
}
