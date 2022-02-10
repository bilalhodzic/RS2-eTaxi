using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Others;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rezervisi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _service;
        public AdminController(IAdmin service)
        {
            _service = service;
        }
        [Authorize(Roles =UserRoles.Admin)]
        [HttpGet("GetAdmins")]
        public virtual Task<IEnumerable<UsersDto>> GetAdmins()
        {
            return _service.GetAdmins();
        }
        [Authorize(Roles =UserRoles.Admin)]
        [HttpPost]
        [Route("ChangeAdminPassword")]
        public virtual async Task<bool> ChangeAdminPass([FromBody] AdminResetPassword reset)
        {
            return await _service.ChangeAdminPass(reset);
        }
    }
}
