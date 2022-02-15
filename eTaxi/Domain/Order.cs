using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class Order
    {
        public Order()
        {
            IsActive = true;
        }

        public int OrderId { get; set; }
        public DateTime OrderCreatedTime { get; set; }
        public bool IsActive { get; set; }
        public int UserDriverId { get; set; }
        public int? UserId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int VehicleId { get; set; }


        public virtual ApplicationUser UserDriver { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual Location StartLocation { get; set; }
        public virtual Location EndLocation { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
