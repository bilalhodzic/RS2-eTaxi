using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests.Rate
{
    public class RateInsertRequest
    {
        public int UserId { get; set; }
        public double PricePerKm { get; set; }
    }
}
