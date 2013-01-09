using System.Web.Mvc;

namespace Molimentum.StaticMapHelpers
{
    /// <summary>
    /// Extensions for ASP.NET MVC HtmlHelper.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Creates a control for creating an img tag for Google Static Maps.
        /// </summary>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="width">Width of the image in pixels.</param>
        /// <param name="height">Height of the image in pixels.</param>
        /// <param name="mapType">Type of map.</param>
        /// <returns>A control that allows further configuration of the map.</returns>
        public static GoogleStaticMapControl GoogleStaticMap(this HtmlHelper html, int width, int height, GoogleMapType mapType)
        {
            return GoogleStaticMap(html, width, height, mapType, null);
        }

        /// <summary>
        /// Creates a control for creating an img tag for Google Static Maps.
        /// </summary>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="width">Width of the image in pixels.</param>
        /// <param name="height">Height of the image in pixels.</param>
        /// <param name="mapType">Type of map.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>A control that allows further configuration of the map.</returns>
        public static GoogleStaticMapControl GoogleStaticMap(this HtmlHelper html, int width, int height, GoogleMapType mapType, object htmlAttributes)
        {
            return new GoogleStaticMapControl(width, height, mapType)
                .AsImage(htmlAttributes);
        }
    }
}
