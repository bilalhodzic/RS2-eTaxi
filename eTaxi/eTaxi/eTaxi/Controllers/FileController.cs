using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rezervisi.Controllers
{
    public class FileController : CRUDController<FileDto, FileSearchRequest, FileInsert, FileUpsert>
    {
        public FileController(ICRUD<FileDto, FileSearchRequest, FileInsert, FileUpsert> service) : base(service)
        {
        }
        [Authorize]
        public override Task<FileDto> Insert([FromForm] FileInsert file)
        {
            return base.Insert(file);
        }

        [Authorize]
        public override Task<FileDto> Update(int id, [FromForm] FileUpsert file)
        {
            return base.Update(id, file);
        }
        [AllowAnonymous]
        public override Task<IEnumerable<FileDto>> Get([FromQuery] FileSearchRequest search = null)
        {
            return base.Get(search);
        }
    }
}
