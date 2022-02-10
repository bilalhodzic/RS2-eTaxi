using Model.Others;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<bool> MobileVerifyEmail(MobileVerifyEmail User)
        {
            var user = await _userManager.FindByIdAsync(User.ID.ToString());

            if (user == null)
            {
                throw new UserException("Nije pronađeno");
            }

            if (user.Pin == User.PIN)
            {
                await _userManager.ConfirmEmailAsync(user, await _userManager.GenerateEmailConfirmationTokenAsync(user));
                user.Pin = null;
                await _userManager.UpdateAsync(user);
                return true;
            }
            else
            {
                throw new UserException("Mail nije moguće poslati. Pokušajte ponovo kasnije!");
            }
        }
    }
    
}
