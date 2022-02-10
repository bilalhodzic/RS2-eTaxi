using Domain;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Users
{
    public partial class Users
    {
        public override async Task<IEnumerable<UsersDto>> Get(object search = null)
        {
            var entity = _context.Set<ApplicationUser>().AsQueryable();
            entity = entity.Where(x => x.UserType != "Admin");
            entity = entity.Where(x => x.IsActive == true);
            var list = await entity.ToListAsync();
            return _mapper.Map<List<UsersDto>>(list);
        }
    }
}
