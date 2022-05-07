using Application.Interfaces;
using Rezervisi.Controllers;
using Model.Dto.Vehicle;
using Model.Requests.Vehicle;

namespace eTaxi.Controllers
{
    public class VehicleTypeController : CRUDController<VehicleTypeDto, VehicleTypeSearchRequest, VehicleTypeInsertRequest, object>
    {
        public VehicleTypeController(ICRUD<VehicleTypeDto, VehicleTypeSearchRequest, VehicleTypeInsertRequest, object> service) : base(service)
        {

        }
    }
}
