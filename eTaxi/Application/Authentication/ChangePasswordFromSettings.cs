using Model.Others;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<bool> ChangePasswordFromSettings(int id, ChangePassword request)
        {
            if (request.NewPassword == request.ConfirmPassword)
            {
                var user = await _userManager.FindByIdAsync(id.ToString());

                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

                    if (result.Succeeded)
                    {
                        return true;
                    }
                    else
                    {
                        throw new UserException("Trenutna lozinka je netačna");
                    }
                }
                else
                {
                    throw new UserException(Messages.UserNotExist);
                }
            }
            else
            {
                throw new UserException("Nova lozinka i lozinka za potvrdu nisu iste.");
            }
        }
    }
}
