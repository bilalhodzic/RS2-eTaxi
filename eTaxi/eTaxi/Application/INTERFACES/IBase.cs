using Model.Dto.Users;
using Model.Others;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBase<T, TSearch> where T : class where TSearch : class
    {
        public Task<IEnumerable<T>> Get(TSearch search = null);
        public Task<T> GetById(int id);
    }
}
