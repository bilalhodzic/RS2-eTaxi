using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial  class Hub
    {
        public int HubId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
