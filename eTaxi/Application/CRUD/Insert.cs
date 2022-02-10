using Microsoft.Data.SqlClient;
using Model.Others;
using System;
using System.Threading.Tasks;

namespace Application.CRUD
{
    public partial class CRUD<T, Tsearch, TDb, TInsert, TUpdate>
    {
        public async virtual Task<T> Insert(TInsert request)
        {
            ValidateApi();
            try
            {
                var set = _context.Set<TDb>();
                TDb entity = _mapper.Map<TDb>(request);
                set.Add(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<T>(entity);

            }
            catch (Exception ex)
            {

                var sqlException = ex.InnerException as SqlException;
                if (sqlException != null)
                {
                    switch (sqlException.Number)
                    {
                        case 2627:  // Unique constraint error
                        case 2601:  // Duplicated key row error
                            throw new UserException("Cannot insert duplicate values.");
                    }
                }
                throw new UserException(Messages.WrongData);

            }
        }
    }
}