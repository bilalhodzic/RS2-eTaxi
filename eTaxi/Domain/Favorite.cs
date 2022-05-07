using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
