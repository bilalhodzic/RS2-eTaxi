using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto.Vehicle;
using Model.Requests.Vehicle;
using Persistence;

namespace Application.Vehicles
{
    public partial class Vehicles : CRUD<VehicleDto, VehicleSearchRequest, Vehicle, VehicleInsertRequest, VehicleUpsertRequest>
    {
        public Vehicles(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}
