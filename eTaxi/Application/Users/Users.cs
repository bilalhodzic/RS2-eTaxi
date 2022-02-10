using Application.CRUDP;
using Application.INTERFACES;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto;
using Model.Dto.Users;
using Model.Requests;
using Persistence;

namespace Application.Users
{
    public partial class Users : CRUDP<UsersDto, object, ApplicationUser, object, UserUpsertRequest, UserPatchDto>, IUser
    {
        public Users(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}
