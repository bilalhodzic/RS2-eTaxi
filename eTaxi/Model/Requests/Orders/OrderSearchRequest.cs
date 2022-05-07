using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests.Orders
{
    public class OrderSearchRequest
    {
        public bool IsActive { get; set; }
        public int UserDriverId { get; set; }
        public int VehicleId { get; set; }
    }
}
