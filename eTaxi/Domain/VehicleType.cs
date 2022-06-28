using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string Type { get; set; }
        public int NumberOfSeats { get; set; }
        public int FileId { get; set; }
        public virtual File File { get; set; }
    }
}
