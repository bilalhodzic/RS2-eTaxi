using Application.Interfaces;
using AutoMapper;
using Persistence;

namespace Application.Base
{
    public partial class Base<T, TDb, TSearch> : IBase<T, TSearch> where T : class where TDb : class where TSearch : class
    {

        protected readonly eTaxiDbContext _context;
        protected readonly IMapper _mapper;

        public Base(eTaxiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
