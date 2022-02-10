using Model.Others;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<Response> ConfirmChangeEmailMobile(ConfirmChangeEmail request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user != null)
            {
                if (user.Pin == Int32.Parse(request.Token) && request.NewEmail != null && request.NewEmail != "")
                {
                    user.Email = request.NewEmail;
                    user.NormalizedEmail = _userManager.NormalizeEmail(request.NewEmail);
                    user.UserName = request.NewEmail;
                    user.NormalizedUserName = _userManager.NormalizeName(request.NewEmail);
                    user.Pin = null;

                    await _userManager.UpdateAsync(user);

                    return new Response { Status = Messages.Success, Message = "E-Mail adresa je uspješno promijenjena", UserId = user.Id };
                }
                else
                {
                    throw new UserException("E-mail adresa se ne može promijeniti");
                }
            }
            else
            {
                throw new UserException("Korisnik nije pronađen");
            }
        }
    }
}
