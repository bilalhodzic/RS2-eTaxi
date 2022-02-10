using Domain;
using Model.Others;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public partial class Authentication
    {
        public async Task<bool> DeactivateAccount(int id)
        {
            var User =  await _userManager.FindByIdAsync(id.ToString());
            if (User == null)
                throw new UserException(Messages.UserNotExist);
   
            User.IsActive = false;
            await _userManager.UpdateAsync(User);
            _context.SaveChanges();
            return true;
        }
    }
}

