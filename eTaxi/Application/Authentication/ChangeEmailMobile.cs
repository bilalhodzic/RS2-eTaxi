using Model.Others;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<bool> ChangeEmailMobile(int id, ChangeEmail request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                if (user.PasswordHash == null)
                {
                    throw new UserException("Ne možete promijeniti E-Mail adresu računa koji je kreirala treća strana.");
                }

                var checkEmail = await _userManager.FindByEmailAsync(request.NewEmail);
                if (checkEmail == null)
                {
                    Random rnd = new Random();
                    int pin = rnd.Next(1000, 9999);
                    user.Pin = pin;
                    await _userManager.UpdateAsync(user);
                    var htmlCode = GetMobileChangeEmailMessage(pin.ToString());
                    var message = new EmailMessage(new string[] { request.NewEmail }, "Promijenite E-Mail", htmlCode);
                    _EmailService.SendEmail(message);

                    return true;
                }
                else
                {
                    throw new UserException("E-mail adresa je već zauzeta");
                }
            }
            else
            {
                throw new UserException("Korisnik nije pronađen");
            }
        }
    }
}
