using Model.Dto;
using Model.Others;
using System.Threading.Tasks;

namespace Application.Users
{
    public partial class Users
    {
        public override Task<UsersDto> GetById(int id)
        {
            if (_context.Users.Find(id).IsActive == false)
                throw new UserException("Korisnik je deaktiviran.");
            return base.GetById(id);
        }
    }
}
