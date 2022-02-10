using Application.Base;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.CRUD
{
    public partial class CRUD<T, Tsearch, TDb, TInsert, TUpdate> : Base<T, TDb, Tsearch>, ICRUD<T, Tsearch, TInsert, TUpdate> where T : class where Tsearch : class
    where TDb : class where TInsert : class where TUpdate : class
    {
        public int ?ID=null;
        public IHttpContextAccessor _httpContextAccessor;
        public CRUD(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
