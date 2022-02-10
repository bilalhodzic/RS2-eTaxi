using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto;
using Model.Requests;
using Persistence;

namespace Application.Locations
{

    public partial class Locations :
        CRUD<LocationDto, LocationSearchRequest, Location, LocationInsertRequest, LocationUpsertRequest>
    {
        public Locations(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}

