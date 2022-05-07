using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto.Vehicle;
using Model.Requests.Vehicle;
using Persistence;

namespace Application.VehicleTypes
{
    public partial class VehicleTypes : CRUD<VehicleTypeDto, VehicleTypeSearchRequest, VehicleType, VehicleTypeInsertRequest, object>
    {
        public VehicleTypes(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}
