using Model.Others;

namespace Application.CRUD
{
    public partial class CRUD<T, Tsearch, TDb, TInsert, TUpdate>
    {
        public virtual void Delete(int id)
        {
            ValidateApi();
            try
            {
                var entity = _context.Set<TDb>().Find(id);
                if (entity == null)
                {
                    throw new UserException("Not found");
                }
                _context.Set<TDb>().Remove(entity);
                _context.SaveChanges();
            }
            catch 
            {
                throw new UserException(Messages.WrongData);
            }
        }
    }
}
