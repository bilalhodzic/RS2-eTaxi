using Model.Others;
using System;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<string> ConfirmChangeEmail(ConfirmChangeEmail request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user != null)
            {
                var result = await _userManager.ChangeEmailAsync(user, request.NewEmail, request.Token);

                if (result.Succeeded)
                {
                    user.UserName = request.NewEmail;

                    await _userManager.UpdateAsync(user);

                    return _appSettings.AppUrl + "/konto/email-geändert";
                }
                else
                {
                    throw new UserException("E-Mail kann nicht geändert werden");
                }
            }
            else
            {
                throw new UserException("Benutzer wurde nicht gefunden");
            }
        }
    }
}
