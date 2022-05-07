using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto.Order;
using Model.Requests.Orders;
using Persistence;

namespace Application.Orders
{
    public partial class Orders : CRUD<OrderDto, OrderSearchRequest, Order, OrderInsertRequest, OrderUpsertRequest>
    {
        public Orders(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}
