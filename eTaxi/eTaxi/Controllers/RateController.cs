using Application.Interfaces;
using Rezervisi.Controllers;
using Model.Dto.Rate;
using Model.Requests.Rate;

namespace eTaxi.Controllers
{
    public class RateController : CRUDController<RateDto, RateSearchRequest, RateInsertRequest, object>
    {
        public RateController(ICRUD<RateDto, RateSearchRequest, RateInsertRequest, object> service) : base(service)
        {

        }
    }
}

