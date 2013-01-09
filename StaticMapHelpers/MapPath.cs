using System.Collections.Generic;

namespace Molimentum.StaticMapHelpers
{
    public class MapPath
    {
        public MapPathStyle Style { get; set; }

        public IEnumerable<Location> Locations { get; set; }
    }
}
