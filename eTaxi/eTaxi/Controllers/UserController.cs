using Application.INTERFACES;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Dto.Users;
using Model.Requests;
using System.Threading.Tasks;

namespace Rezervisi.Controllers
{
    public class UserController : CRUDPController<UsersDto, object, object, UserUpsertRequest, UserPatchDto>
    {
        private readonly IUser _services;
        public UserController(IUser service) : base(service)
        {
            _services = service;
        }

        [AllowAnonymous]
        public override Task<UsersDto> GetById(int id)
        {
            return base.GetById(id);
        }
        [HttpPost("NumberVerification")]
        [Authorize]
        public async Task<bool> NumberVerification(string uid)
        {
            return await _services.NumberVerification(uid);
        }
    }

}
