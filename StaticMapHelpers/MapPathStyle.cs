namespace Molimentum.StaticMapHelpers
{
    /// <summary>
    /// Style for a path, see
    /// https://developers.google.com/maps/documentation/staticmaps/#PathStyles
    /// for details.
    /// </summary>
    public class MapPathStyle
    {
        /// <summary>
        /// Weight for the path, see
        /// https://developers.google.com/maps/documentation/staticmaps/#PathStyles
        /// for details.
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Color for the path, see
        /// https://developers.google.com/maps/documentation/staticmaps/#PathStyles
        /// for details.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Fill color for the path, see
        /// https://developers.google.com/maps/documentation/staticmaps/#PathStyles
        /// for details.
        /// </summary>
        public string FillColor { get; set; }
    }
}
