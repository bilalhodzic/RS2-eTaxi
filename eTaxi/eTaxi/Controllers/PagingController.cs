using Application.INTERFACES;
using Microsoft.AspNetCore.Mvc;
using Model.Others;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rezervisi.Controllers
{
    public class PagingController<T, TSearch, TInsert, TUpdate> : CRUDController<T, TSearch, TInsert, TUpdate> where T : class where TSearch : class where TInsert : class where TUpdate : class 
    {
        private readonly IPaging<T, TSearch, TInsert, TUpdate> _crudService;
        public PagingController(IPaging<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _crudService = service;
        }
        [HttpGet("Paging")]
        public  virtual PagingModel<T> GetAll([FromQuery] PagingParameters Parameters, [FromQuery] TSearch search=null)
        {
            return   _crudService.GetAll(Parameters,search);
        }

        public override Task<IEnumerable<T>> Get([FromQuery] TSearch search = null)
        {
            throw new UserException("Not valid for this table.");
        }
    }

    
}
