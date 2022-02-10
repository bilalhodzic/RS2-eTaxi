using Microsoft.AspNetCore.JsonPatch;
using Model.Others;
using System.Threading.Tasks;

namespace Application.CRUDP
{
    public partial class CRUDP<T, Tsearch, TDb, TInsert, TUpdate, TPartialUpdate>
    {
        public async virtual  Task<bool> ParitialUpdate(int id, JsonPatchDocument<TPartialUpdate> request)
        {
            if (request == null)
            {
                throw new UserException("Vom Client gesendetes Objekt ist null.");
            }
            var set = _context.Set<TDb>();

            var Entity = await set.FindAsync(id);
            if (Entity == null)
            {
                throw new UserException($"Entität mit ID: {id} existiert nicht in der Datenbank.");
            }

            try
            {
                var userToPatch = _mapper.Map<TPartialUpdate>(Entity);
                request.ApplyTo(userToPatch);
                _mapper.Map(userToPatch, Entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                throw new UserException(Messages.WrongData);
            }

        }
    }
}
