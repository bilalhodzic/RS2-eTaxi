using Application.Interfaces;
using Model.Dto;
using Model.Requests;

namespace Rezervisi.Controllers
{

    public class LocationController : CRUDController<LocationDto, LocationSearchRequest, LocationInsertRequest, LocationUpsertRequest>
    {
        public LocationController(ICRUD<LocationDto, LocationSearchRequest, LocationInsertRequest, LocationUpsertRequest> service) : base(service)
        {

        }
    }
}
