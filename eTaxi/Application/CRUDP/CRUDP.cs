using Application.CRUD;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.CRUDP
{
    public partial class CRUDP<T, Tsearch, TDb, TInsert, TUpdate, TPartialUpdate> : CRUD<T, Tsearch, TDb, TInsert, TUpdate>, ICRUDP<T, Tsearch, TInsert, TUpdate, TPartialUpdate> where T : class where Tsearch : class
      where TDb : class where TInsert : class where TUpdate : class where TPartialUpdate : class
    {
        public CRUDP(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper,httpContextAccessor)
        {
        }
    }
}
