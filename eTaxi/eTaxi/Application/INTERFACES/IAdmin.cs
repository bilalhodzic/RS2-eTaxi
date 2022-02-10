using Model.Dto;
using Model.Others;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdmin
    {
        public Task<IEnumerable<UsersDto>> GetAdmins();
        public Task<bool> ChangeAdminPass(AdminResetPassword reset);

    }
}
