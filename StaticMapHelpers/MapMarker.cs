using System.Collections.Generic;

namespace Molimentum.StaticMapHelpers
{
    public class MapMarker
    {
        public MapMarkerStyle Style { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        public Location Location
        {
            set
            {
                Locations = new[] { value };
            }
        }
    }
}
