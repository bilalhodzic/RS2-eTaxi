using Application.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Rezervisi.Controllers
{
    public class CRUDPController<T, TSearch, TInsert, TUpdate, TPartialUpdate> : CRUDController<T, TSearch, TInsert, TUpdate> where T : class where TSearch : class where TInsert : class where TUpdate : class where TPartialUpdate : class
    {
        private readonly ICRUDP<T, TSearch, TInsert, TUpdate, TPartialUpdate> _crudService;
        public CRUDPController(ICRUDP<T, TSearch, TInsert, TUpdate, TPartialUpdate> service) : base(service)
        {
            _crudService = service;
        }
        [HttpPatch("{id}")]
        public Task<bool> PartialUpdate(int id, [FromBody] JsonPatchDocument<TPartialUpdate> request)
        {
           return _crudService.ParitialUpdate(id, request);
        }
    }
}
