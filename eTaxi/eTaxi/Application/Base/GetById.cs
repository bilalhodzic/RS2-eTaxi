using Model.Others;
using System.Threading.Tasks;

namespace Application.Base
{
    public partial class Base<T, TDb, TSearch>
    {
        public async virtual Task<T> GetById(int id)
        {
            try
            {
                var entity = _context.Set<TDb>();
                var obj = await entity.FindAsync(id);
                return _mapper.Map<T>(obj);
            }
            catch 
            {
                throw new UserException(Messages.WrongData);
            }

        }
    }
}
