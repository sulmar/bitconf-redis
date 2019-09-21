namespace BitConf.Models
{
    public class Location : Base
    {
        public string VehicleId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class LocationInfo : Location
    {
      
        public double Distance { get; set; }
    }
}
