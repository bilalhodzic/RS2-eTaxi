using Microsoft.EntityFrameworkCore;
using Model.Others;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Base
{
    public partial class Base<T, TDb, TSearch>
    {
        public virtual async Task<IEnumerable<T>> Get(TSearch search = null)
        {
            try
            {
                var ListDB = await _context.Set<TDb>().ToListAsync();
                var ListModel = _mapper.Map<IEnumerable<T>>(ListDB);
                return _mapper.Map<IEnumerable<T>>(ListModel);
            }
            catch 
            {
                throw new UserException(Messages.WrongData);
            }
        }
    }
}
