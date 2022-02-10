using Application.CRUD;
using Application.INTERFACES;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Persistence;
using System.Linq;

namespace Application.Paging
{
   public partial class Paging<T, Tsearch, TDb, TInsert, TUpdate> : CRUD<T, Tsearch, TDb, TInsert, TUpdate>, IPaging<T, Tsearch, TInsert, TUpdate> where T : class where Tsearch : class
   where TDb : class where TInsert : class where TUpdate : class
    {
        public Paging(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper,httpContextAccessor)
        {
        }
        public virtual IQueryable<TDb> getList() {
            return null;
        }
    }
}
