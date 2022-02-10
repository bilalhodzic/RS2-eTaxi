using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class Location
    {
        public Location()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public int LocationId { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FormattedAddress { get; set; }
        public string Radius { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }


    }
}
