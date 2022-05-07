using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto.Rate
{
    public class RateDto
    {
        public int RateId { get; set; }
        public int UserId { get; set; }
        public double PricePerKm { get; set; }
    }
}
