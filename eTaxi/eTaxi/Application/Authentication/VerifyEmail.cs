using Model.Others;
using System;
using System.Threading.Tasks;
using System.Web;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<string> VerifyEmail(VerifyEmail User)
        {
            var user = await _userManager.FindByIdAsync(User.UserID);

            if (user == null)
            {
                throw new UserException("Nicht gefunden");
            }

            await _userManager.SetLockoutEnabledAsync(user, false);
            var result = await _userManager.ConfirmEmailAsync(user, User.Token);
            if (result.Succeeded)
            {
                var fullUrl = _appSettings.AppUrl + "/NICIJAZEMLJAJOS";
                var uri = new Uri(fullUrl);
                return uri.AbsoluteUri;
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    throw new UserException(item.Description);
                }
                throw new UserException("Error list empty");
            }
        }
    }
}
