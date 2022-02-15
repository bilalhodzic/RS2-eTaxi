using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public int UserDriverId { get; set; }
        public DateTime CreatedTime { get; set; }
        public double KmTraveled { get; set; }
        public string LicenceNumber { get; set; }
        public int Year { get; set; }
        public bool  AirCondition { get; set; }
        public int CurrentLocationId { get; set; }

        public int TypeId { get; set; }

        public virtual VehicleType Type { get; set; }
        public  virtual Location CurrentLocation { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
