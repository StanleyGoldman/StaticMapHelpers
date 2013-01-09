using System.Collections.Generic;

namespace Molimentum.StaticMapHelpers
{
    public class Marker
    {
        public MarkerStyle Style { get; set; }

        public IEnumerable<Location> Locations { get; set; }
    }
}
