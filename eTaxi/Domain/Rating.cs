using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int UserDriverId { get; set; }
        public int OrderId { get; set; }
        public int Grade { get; set; }
        public string? Comment { get; set; }

        public virtual  ApplicationUser User { get; set; }
        public virtual ApplicationUser UserDriver { get; set; }
        public virtual  Order Order { get; set; }
    }
}
