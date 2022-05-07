using Application.Interfaces;
using Rezervisi.Controllers;
using Model.Dto.Rating;
using Model.Requests.Rating;

namespace eTaxi.Controllers
{
    public class RatingController : CRUDController<RatingDto, RatingSearchRequest, RatingInsertRequest, object>
    {
        public RatingController(ICRUD<RatingDto, RatingSearchRequest, RatingInsertRequest, object> service) : base(service)
        {

        }
    }
}
