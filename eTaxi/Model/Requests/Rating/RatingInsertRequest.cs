using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests.Rating
{
    public class RatingInsertRequest
    {
        public int UserId { get; set; }
        public int UserDriverId { get; set; }
        public int OrderId { get; set; }
        public int Grade { get; set; }
        public string? Comment { get; set; }
    }
}
