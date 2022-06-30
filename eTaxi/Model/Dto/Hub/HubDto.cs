using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto.Hub
{
    public  class HubDto
    {
        public int HubId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
