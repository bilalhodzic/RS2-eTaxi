using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Model.Dto.Vehicle
{
    public class VehicleTypeDto
    {
        public int VehicleTypeId { get; set; }
        public string Type { get; set; }
        public int NumberOfSeats { get; set; }
        public string File { get; set; }
    }
}
