using Microsoft.EntityFrameworkCore;
using Model.Others;
using System.Threading.Tasks;

namespace Application.CRUD
{
    public partial class CRUD<T, Tsearch, TDb, TInsert, TUpdate>
    {
        public async virtual Task<T> Update(int id, TUpdate request)
        {
            ValidateApi();
            try
            {
                var set = _context.Set<TDb>();
                var entity = await set.FindAsync(id);
                _mapper.Map(request, entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<T>(entity);
            }
            catch 
            {
                throw new UserException(Messages.WrongData);
            }
        }
    }
}
