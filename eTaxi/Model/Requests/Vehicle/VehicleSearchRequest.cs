using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests.Vehicle
{
    public class VehicleSearchRequest
    {
        public string LicenceNumber { get; set; }
        public int Year { get; set; }
        public bool AirCondition { get; set; }
        public int CurrentLocationId { get; set; }

        public int TypeId { get; set; }
    }
}
