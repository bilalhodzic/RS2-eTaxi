namespace Model.Requests
{
    public class LocationUpsertRequest
    {
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

    }
}
