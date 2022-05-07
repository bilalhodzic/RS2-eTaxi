using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dto.Favorites;
using Model.Requests.Favorites;
using Rezervisi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTaxi.Controllers
{

    public class FavoritesController : CRUDController<FavoritesDto, FavoritesSearchRequest, FavoritesInsertRequest, FavoritesInsertRequest>
    {
        public FavoritesController(ICRUD<FavoritesDto, FavoritesSearchRequest, FavoritesInsertRequest, FavoritesInsertRequest> service) : base(service)
        {
        }
    }
}
