using Model.Others;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {

        public async Task<Response> MobileResetPassword(MobileResetPassword model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (model.Password != model.ConfirmPassword)
                throw new UserException("Lozinka se ne podudara");
            if (user.Pin == model.Pin)
            {
                var result = await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), model.Password);
                if (user != null)
                {
                    if (result.Succeeded)
                    {
                        user.Pin = null;
                        await _userManager.UpdateAsync(user);
                        return new Response { Status = Messages.Success, Message = "Lozinka je uspješno promijenjena", UserId=user.Id };

                    }
                    else
                    {
                        throw new UserException("Pin za poništavanje je nevažeći ");
                    }
                }
                else
                {
                    throw new UserException("Ne postoji račun s ovom e-poštom.");

                }
            }
            else
                throw new UserException("Pogrešan pin");
            throw new UserException(Messages.InternalError);
        }
    }
}
