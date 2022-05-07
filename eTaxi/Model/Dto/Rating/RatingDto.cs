using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto.Rating
{
    public class RatingDto
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int UserDriverId { get; set; }
        public int OrderId { get; set; }
        public int Grade { get; set; }
        public string? Comment { get; set; }
    }
}
