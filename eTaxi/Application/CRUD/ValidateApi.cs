using Model.Others;

namespace Application.CRUD
{
    public partial class CRUD<T, Tsearch, TDb, TInsert, TUpdate>
    {
        public bool ValidateApi()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("UserId").Value;
            if (ID != null)
            {
                if (ID?.ToString() != userId)
                {
                    throw new UserException("Invalid operation");
                }
            }
            return true;
        }
    }
}
