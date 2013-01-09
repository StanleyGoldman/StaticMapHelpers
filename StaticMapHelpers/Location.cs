using System;
using System.Globalization;

namespace Molimentum.StaticMapHelpers
{
    /// <summary>
    /// A location to be used with the Google Static Maps API V2. Can either
    /// be a latitude/longitude pair, or an address string that gets resolved
    /// by the API.
    /// </summary>
    public class Location
    {
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Location(string address)
        {
            Address = address;
        }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Address { get; set; }


        public override string ToString()
        {
            if (Address != null)
                return Address;

            if (Latitude != null && Longitude != null)
                return String.Format(NumberFormatInfo.InvariantInfo, "{0},{1}", Latitude, Longitude);

            return "Undefined";
        }
    }
}