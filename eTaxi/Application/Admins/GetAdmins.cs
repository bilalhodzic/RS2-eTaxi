using Domain;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Admins
{
    public partial class Admins
    {
      public async Task<IEnumerable<UsersDto>> GetAdmins()
      {
          var entity = _context.Set<ApplicationUser>().AsQueryable();
          entity = entity.Where(x => x.UserType == "Admin");
          var list = await entity.ToListAsync();
          return _mapper.Map<List<UsersDto>>(list);
      }
        
    }
}
