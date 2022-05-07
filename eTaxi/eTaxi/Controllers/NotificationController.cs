using Application.Interfaces;
using Rezervisi.Controllers;
using Model.Dto.Order;
using Model.Requests.Orders;

namespace eTaxi.Controllers
{
    public class OrderController : CRUDController<OrderDto, OrderSearchRequest, OrderInsertRequest, OrderUpsertRequest>
    {
        public OrderController(ICRUD<OrderDto, OrderSearchRequest, OrderInsertRequest, OrderUpsertRequest> service) : base(service)
        {

        }
    }
}
