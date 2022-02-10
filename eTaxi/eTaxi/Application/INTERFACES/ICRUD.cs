using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICRUD<T, Tsearch, TInsert, TUpdate> : IBase<T, Tsearch> where T : class where Tsearch : class
       where TInsert : class where TUpdate : class
    {
        Task<T> Insert(TInsert request);
        Task<T> Update(int id, TUpdate request);
        void Delete(int id);
    }
}
