using Domain;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using Model.Others;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Locations
{
    public partial class Locations
    {
        public override async Task<LocationDto> GetById(int id)
        {
            try
            {
                var entity = _context.Set<Location>().AsQueryable();
                entity = entity.Where(x => x.LocationId == id);
                return _mapper.Map<LocationDto>(await entity.FirstOrDefaultAsync());
            }
            catch
            {
                throw new UserException(Messages.WrongData);
            }
        }
    }

}
