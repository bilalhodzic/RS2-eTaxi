using System.Collections.Generic;

namespace Model.Others
{
    public class PagingModel<Dto>
    {
        public IEnumerable<Dto> list { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
