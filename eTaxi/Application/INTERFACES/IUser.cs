using Application.Interfaces;
using Model.Dto;
using Model.Dto.Users;
using Model.Requests;
using System.Threading.Tasks;

namespace Application.INTERFACES
{
    public interface IUser : ICRUDP<UsersDto, object, object, UserUpsertRequest, UserPatchDto>
    {
        public Task<bool> NumberVerification(string uid);
    }
}
