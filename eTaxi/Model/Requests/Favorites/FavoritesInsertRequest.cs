using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests.Favorites
{
    public class FavoritesInsertRequest
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }
}
