using System;
using System.Collections.Generic;

namespace Model.Others
{
    public class TimeRequirements
    {
        public List<int> SalonServiceIds { get; set; }
        public int EmployeeId { get; set; }
        public int SalonId { get; set; }
        public DateTime Time { get; set; }
    }
}
