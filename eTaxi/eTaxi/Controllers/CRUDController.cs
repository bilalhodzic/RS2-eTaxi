using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Rezervisi.Controllers
{

    public class CRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        private readonly ICRUD<T, TSearch, TInsert, TUpdate> _crudService;
        public CRUDController(ICRUD<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _crudService = service;
        }

        [Authorize]
        [HttpPost]
        public virtual Task<T> Insert([FromBody] TInsert request)
        {
            return _crudService.Insert(request);
        }

        [Authorize]
        [HttpPut("{id}")]
        public virtual Task<T> Update(int id, [FromBody] TUpdate request)
        {
            return _crudService.Update(id, request);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _crudService.Delete(id);
        }

    }
}
