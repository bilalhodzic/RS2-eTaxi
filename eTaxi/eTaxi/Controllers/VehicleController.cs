using Application.Interfaces;
using Rezervisi.Controllers;
using Model.Dto.Vehicle;
using Model.Requests.Vehicle;

namespace eTaxi.Controllers
{
    public class VehicleController : CRUDController<VehicleDto, VehicleSearchRequest, VehicleInsertRequest, VehicleUpsertRequest>
    {
        public VehicleController(ICRUD<VehicleDto, VehicleSearchRequest, VehicleInsertRequest, VehicleUpsertRequest> service) : base(service)
        {

        }
    }
}
