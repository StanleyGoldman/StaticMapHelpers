namespace Molimentum.StaticMapHelpers
{
    /// <summary>
    /// Style for a marker, see
    /// https://developers.google.com/maps/documentation/staticmaps/#MarkerStyles
    /// for details.
    /// </summary>
    public class MarkerStyle
    {
        public MarkerStyle()
        {
            Shadow = true;
        }

        /// <summary>
        /// Size of the marker, see
        /// https://developers.google.com/maps/documentation/staticmaps/#MarkerStyles
        /// for details.
        /// </summary>
        public MarkerSize Size { get; set; }

        /// <summary>
        /// Color for the marker, see
        /// https://developers.google.com/maps/documentation/staticmaps/#MarkerStyles
        /// for details.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Label for the marker, see
        /// https://developers.google.com/maps/documentation/staticmaps/#MarkerStyles
        /// for details.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Icon url for the marker, see
        /// https://developers.google.com/maps/documentation/staticmaps/#CustomIcons
        /// for details.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Shadow for the marker, see
        /// https://developers.google.com/maps/documentation/staticmaps/#CustomIcons
        /// for details.
        /// </summary>
        public bool Shadow { get; set; }
    }
}
