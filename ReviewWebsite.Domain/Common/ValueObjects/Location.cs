using ReviewWebsite.Domain.Common.Models;

namespace ReviewWebsite.Domain.Common.ValueObjects
{
    public class Location : ValueObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }    
        public double Longitude { get; set; }

        private Location(
            string name,
            string address,
            double latitude,
            double longtitude) 
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longtitude;
        }

        public Location Create(
            string name,
            string address,
            double latitude,
            double longtitude)
        {
            return new Location(
                name,
                address,
                latitude,
                longtitude);   
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
