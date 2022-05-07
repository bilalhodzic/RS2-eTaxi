using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto.Rate;
using Model.Requests.Rate;
using Persistence;

namespace Application.Rates
{
    public partial class Rates : CRUD<RateDto, RateSearchRequest, Rate, RateInsertRequest, object>
    {
        public Rates(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}
