using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rezervisi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController<T, Tsearch> : ControllerBase where T : class where Tsearch : class
    {
        protected readonly IBase<T, Tsearch> _service;
        public BaseController(IBase<T, Tsearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public async virtual Task<IEnumerable<T>> Get([FromQuery] Tsearch search = null)
        {
            return await _service.Get(search);
        }

        [HttpGet("{id}")]
        public  virtual Task<T> GetById(int id)
        {
            return _service.GetById(id);
        }

    }

}
