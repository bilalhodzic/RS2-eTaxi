using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests.Vehicle
{
    public class VehicleUpsertRequest
    {
        public double KmTraveled { get; set; }
        public int CurrentLocationId { get; set; }

    }
}
