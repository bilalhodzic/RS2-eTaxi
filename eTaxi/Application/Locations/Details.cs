using Domain;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using Model.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Application.Locations
{

    public partial class Locations
    {
        public override async Task<IEnumerable<LocationDto>> Get(LocationSearchRequest search = null)
        {
            var entity = _context.Set<Location>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.City))
            {
                entity = entity.Where(x => x.City.Contains(search.City));
            }
            if (!string.IsNullOrWhiteSpace(search?.StreetNumber))
            {
                entity = entity.Where(x => x.StreetNumber.Contains(search.StreetNumber));
            }
            if (!string.IsNullOrWhiteSpace(search?.PostalCode))
            {
                entity = entity.Where(x => x.PostalCode.Contains(search.PostalCode));
            }
            var list = await entity.ToListAsync();
            return _mapper.Map<IEnumerable<LocationDto>>(list);
        }


    }


}
