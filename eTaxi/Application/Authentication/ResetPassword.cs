using Model.Others;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<Response> ResetPassword(ResetPassword model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (model.Password != model.ConfirmPassword)
                throw new UserException("Passwort stimmt nicht überein");
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (user != null)
            {
                if (result.Succeeded)
                {
                    return new Response { Status = Messages.Success, Message = "Password has been sucessfully changed.", UserId=user.Id };
                }
                else
                {
                    throw new UserException("Reset-Token ist ungültig");
                }
            }
            else
            {
                throw new UserException("Es gibt kein Konto mit dieser E-Mail.");

            }
            throw new UserException(Messages.InternalError);
        }
    }
}
