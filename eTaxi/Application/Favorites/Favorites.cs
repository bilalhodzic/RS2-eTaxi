using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto.Favorites;
using Model.Requests.Favorites;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Favorites
{
    public partial class Favorites : CRUD<FavoritesDto, FavoritesSearchRequest, Favorite, FavoritesInsertRequest, FavoritesInsertRequest>
    {
        public Favorites(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}
