using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class Rate
    {
        public int RateId { get; set; }
        public int UserId { get; set; }
        public double PricePerKm { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
