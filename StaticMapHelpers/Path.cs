using System.Collections.Generic;

namespace Molimentum.StaticMapHelpers
{
    public class Path
    {
        public PathStyle Style { get; set; }

        public IEnumerable<Location> Locations { get; set; }
    }
}
