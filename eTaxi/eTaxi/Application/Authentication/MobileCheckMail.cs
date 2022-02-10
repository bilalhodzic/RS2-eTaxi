using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<bool> MobileCheckMail(string email) {
            if(await _userManager.FindByEmailAsync(email)!=null)
                return true;
            return false;
        }

    }
}
