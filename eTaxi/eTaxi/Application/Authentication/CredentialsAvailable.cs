using Model.Others;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<bool> CredentialsAvailable(Register model)
        {
            if (model.Password == model.ConfirmPassword)
            {
                var userUsername = await _userManager.FindByNameAsync(model.UserName);
                var userEmail = await _userManager.FindByEmailAsync(model.Email);

                if (userEmail != null)
                {
                    throw new UserException("E-Mail već postoji");
                }
                if (userUsername != null)
                {
                    throw new UserException("Korisničko ime već postoji");
                }

                return true;
            }
            else
            {
                throw new UserException("Lozinke se ne podudaraju");
            }
        }
    }
}
