using Microsoft.AspNetCore.JsonPatch;
using Model.Dto.Users;
using System.Threading.Tasks;

namespace Application.Users
{
    public partial class Users
    {
        public override Task<bool> ParitialUpdate(int id, JsonPatchDocument<UserPatchDto> request)
        {
            ID = id;
            ValidateApi();
            return base.ParitialUpdate(id, request);
        }
    }
}
