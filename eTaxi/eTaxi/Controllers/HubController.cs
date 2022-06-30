using Application.Interfaces;
using Domain;
using Model.Dto.Hub;
using Model.Requests.Hub;
using Rezervisi.Controllers;

namespace eTaxi.Controllers
{
    public class HubController : CRUDController<HubDto, object, HubInsertRequest, object>
    {
        public HubController(ICRUD<HubDto, object, HubInsertRequest, object> service) : base(service)
        {
        }
    }
}
