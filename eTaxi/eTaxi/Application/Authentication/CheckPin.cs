using Model.Others;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<bool> CheckPin(int id, int pin)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user.Pin == pin)
                return true;
            else
                throw new UserException("Pogrešan pin");
        }

    }
}
