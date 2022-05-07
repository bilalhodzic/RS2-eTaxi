using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto.Rating;
using Model.Requests.Rating;
using Persistence;

namespace Application.Ratings
{
    public partial class Ratings : CRUD<RatingDto, RatingSearchRequest, Rating, RatingInsertRequest, object>
    {
        public Ratings(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}

