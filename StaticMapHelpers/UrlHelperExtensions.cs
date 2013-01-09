using System.Web.Mvc;

namespace Molimentum.StaticMapHelpers.Extensions
{
    /// <summary>
    /// Extensions for ASP.NET MVC UrlHelper.
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Creates a control for creating an url for Google Static Maps.
        /// </summary>
        /// <param name="url">The Url helper instance that this method extends.</param>
        /// <param name="width">Width of the image in pixels.</param>
        /// <param name="height">Height of the image in pixels.</param>
        /// <param name="mapType">Type of map.</param>
        /// <returns>A control that allows further configuration of the map.</returns>
        public static GoogleStaticMapControl GoogleStaticMap(this UrlHelper url, int width, int height, GoogleMapType mapType)
        {
            return new GoogleStaticMapControl(width, height, mapType)
                .AsUrl();
        }
    }
}
