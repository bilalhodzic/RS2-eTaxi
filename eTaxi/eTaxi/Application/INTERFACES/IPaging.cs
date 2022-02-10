using Application.Interfaces;
using Model.Others;

namespace Application.INTERFACES
{

    public interface IPaging<T, Tsearch, TInsert, TUpdate> : ICRUD<T, Tsearch, TInsert, TUpdate> where T : class where Tsearch : class
    where TInsert : class where TUpdate : class
    {
        PagingModel<T> GetAll(PagingParameters Parameters, Tsearch search = null);
    }
}
