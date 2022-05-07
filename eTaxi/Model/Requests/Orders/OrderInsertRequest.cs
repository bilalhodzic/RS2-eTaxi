using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests.Orders
{
    public class OrderInsertRequest
    {
        public int UserDriverId { get; set; }
        public int? UserId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int VehicleId { get; set; }
    }
}
