using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Requests.Vehicle
{
    public class VehicleTypeSearchRequest
    {
        public string Type { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
