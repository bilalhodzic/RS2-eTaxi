using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderCreatedTime { get; set; }
        public bool IsActive { get; set; }
        public int UserDriverId { get; set; }
        public int? UserId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int VehicleId { get; set; }
    }
}
