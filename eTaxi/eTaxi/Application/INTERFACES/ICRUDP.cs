using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICRUDP<T, Tsearch, TInsert, TUpdate, TPartialUpdate> : ICRUD<T, Tsearch, TInsert, TUpdate> where T : class where Tsearch : class
       where TInsert : class where TUpdate : class where TPartialUpdate : class
    {
        Task<bool> ParitialUpdate(int id, JsonPatchDocument<TPartialUpdate> request);
    }
}
