using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Files = new HashSet<File>();
            CreatedTime = DateTime.Now;
        }
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public double KmTraveled { get; set; }
        public string LicenceNumber { get; set; }
        public int Year { get; set; }
        public bool  AirCondition { get; set; }
        public bool AirBag { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int CurrentLocationId { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int PricePerKm { get; set; }
        public int? UserDriverId { get; set; }
        public int TypeId { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public virtual VehicleType Type { get; set; }
        public  virtual Location CurrentLocation { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
