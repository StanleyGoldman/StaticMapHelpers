using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Molimentum.StaticMapHelpers
{
    /// <summary>
    /// Control for creating img tags and urls for Google Static Maps.
    /// </summary>
    public class GoogleStaticMapControl : IHtmlString
    {
        private GoogleStaticMapUrlBuilder _urlBuilder;
        private object _htmlAttributes;
        private RenderMode _renderMode;

        /// <summary>
        /// Initializes the control.
        /// </summary>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="width">Width of the image in pixels.</param>
        /// <param name="height">Height of the image in pixels.</param>
        /// <param name="mapType">Type of map.</param>
        public GoogleStaticMapControl(int width, int height, GoogleMapType mapType)
        {
            _urlBuilder = new GoogleStaticMapUrlBuilder(width, height, mapType);

            _renderMode = RenderMode.Image;
        }

        /// <summary>
        /// If <see cref="GoogleStaticMapControl.AsUrl"/> has been called, returns
        /// a url for the settings that have been specified before. Otherwise
        /// returns an html img tag.
        /// </summary>
        /// <returns>String containing an html img tag or a url.</returns>
        public string ToHtmlString()
        {
            switch(_renderMode)
            {
                case RenderMode.Image:
                    return CreateImageTag();

                case RenderMode.Url:
                    return _urlBuilder.ToString();

                default:
                    throw new InvalidOperationException("RenderMode is set to an unhandled value: " + _renderMode);
            }
        }

        /// <summary>
        /// Creates an html img tag with the settings that have been
        /// specified before.
        /// </summary>
        /// <returns>String containing an html img tag.</returns>
        protected string CreateImageTag()
        {
            var imgBuilder = new TagBuilder("img");

            imgBuilder.Attributes["src"] = _urlBuilder.ToString();
            imgBuilder.Attributes["width"] = _urlBuilder.Width.ToString();
            imgBuilder.Attributes["height"] = _urlBuilder.Height.ToString();

            if (_htmlAttributes != null) imgBuilder.MergeAttributes(new RouteValueDictionary(_htmlAttributes));

            return imgBuilder.ToString(TagRenderMode.SelfClosing);
        }

        /// <summary>
        /// The control to renders an HTML img tag.
        /// </summary>
        /// <returns></returns>
        public GoogleStaticMapControl AsImage()
        {
            return AsImage(null);
        }

        /// <summary>
        /// The control to renders an HTML img tag.
        /// </summary>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AsImage(object htmlAttributes)
        {
            _renderMode = RenderMode.Image;
            _htmlAttributes = htmlAttributes;

            return this;
        }

        /// <summary>
        /// The control to renders the URL for the static map. Can be used
        /// for the src attribute of img tags.
        /// </summary>
        /// <returns></returns>
        public GoogleStaticMapControl AsUrl()
        {
            _renderMode = RenderMode.Url;

            return this;
        }

        /// <summary>
        /// Sets sensor usage to <c>true</c>, see
        /// https://developers.google.com/maps/documentation/staticmaps/
        /// for details.
        /// </summary>
        /// <returns></returns>
        public GoogleStaticMapControl UsingSensor()
        {
            return UsingSensor(true);
        }

        /// <summary>
        /// Sets sensor usage to <paramref name="usingSensor" />, see
        /// https://developers.google.com/maps/documentation/staticmaps/
        /// for details.
        /// </summary>
        /// <returns></returns>
        public GoogleStaticMapControl UsingSensor(bool usingSensor)
        {
            _urlBuilder.UsingSensor = usingSensor;

            return this;
        }

        /// <summary>
        /// An https url is created instead of the default http.
        /// </summary>
        /// <returns></returns>
        public GoogleStaticMapControl UseHttps()
        {
            return UseHttps(true);
        }

        /// <summary>
        /// If <paramref name="useHttps" /> is <c>true</c>, an
        /// https url is created, if <c>false</c> an http url.
        /// </summary>
        /// <returns></returns>
        public GoogleStaticMapControl UseHttps(bool useHttps)
        {
            _urlBuilder.UseHttps = useHttps;

            return this;
        }

        /// <summary>
        /// Sets the center of the map to the specified location.
        /// </summary>
        /// <param name="location">Location to center the map on.</param>
        /// <returns></returns>
        public GoogleStaticMapControl CenterOn(Location location)
        {
            _urlBuilder.Center = location;

            return this;
        }

        /// <summary>
        /// Sets the center of the map to the specified location.
        /// </summary>
        /// <param name="latitude">Latitude to center the map on.</param>
        /// <param name="longitude">Longitude to center the map on.</param>
        /// <returns></returns>
        public GoogleStaticMapControl CenterOn(double latitude, double longitude)
        {
            return CenterOn(new Location(latitude, longitude));
        }

        /// <summary>
        /// Sets the center of the map to the specified location.
        /// </summary>
        /// <param name="address">Address to be resolved and to center the map on.</param>
        /// <returns></returns>
        public GoogleStaticMapControl CenterOn(string address)
        {
            return CenterOn(new Location(address));
        }

        /// <summary>
        /// Sets the zoom level of the map, see
        /// https://developers.google.com/maps/documentation/staticmaps/
        /// for details.
        /// </summary>
        /// <param name="zoom">The zoom level.</param>
        /// <returns></returns>
        public GoogleStaticMapControl Zoom(int zoom)
        {
            _urlBuilder.Zoom = zoom;

            return this;
        }

        /// <summary>
        /// Sets the scale for the image, see
        /// https://developers.google.com/maps/documentation/staticmaps/
        /// for details.
        /// </summary>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public GoogleStaticMapControl Scale(int scale)
        {
            _urlBuilder.Scale = scale;

            return this;
        }

        /// <summary>
        /// Adds the markers to the control.
        /// </summary>
        /// <param name="markers">Markers to add.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarkers(IEnumerable<Marker> markers)
        {
            foreach (var marker in markers)
            {
                _urlBuilder.Markers.Add(marker);
            }

            return this;
        }

        /// <summary>
        /// Adds the marker to the control.
        /// </summary>
        /// <param name="marker">Marker to add.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(Marker marker)
        {
            _urlBuilder.Markers.Add(marker);

            return this;
        }

        /// <summary>
        /// Creates a new marker and adds it to the control.
        /// </summary>
        /// <param name="location">Location for the new marker.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(Location location)
        {
            AddMarker(
                new Marker
                {
                    Location = location
                });

            return this;
        }

        /// <summary>
        /// Creates a new marker and adds it to the control.
        /// </summary>
        /// <param name="address">Address to be resolved and to used for the location.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(string address)
        {
            return AddMarker(new Location(address));
        }

        /// <summary>
        /// Creates a new marker and adds it to the control.
        /// </summary>
        /// <param name="latitude">Latitude to use for the location.</param>
        /// <param name="longitude">Longitude to center the location.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(double latitude, double longitude)
        {
            return AddMarker(new Location(latitude, longitude));
        }

        /// <summary>
        /// Creates a new marker and adds it to the control.
        /// </summary>
        /// <param name="style">Style for the new marker.</param>
        /// <param name="location">Location for the new marker.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(MarkerStyle style, Location location)
        {
            return AddMarker(
                new Marker
                {
                    Style = style,
                    Location = location
                });
        }

        /// <summary>
        /// Creates a new marker and adds it to the control.
        /// </summary>
        /// <param name="style">Style for the new marker.</param>
        /// <param name="address">Address to be resolved and to used for the location.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(MarkerStyle style, string address)
        {
            return AddMarker(style, new Location(address));
        }
        
        /// <summary>
        /// Creates a new marker and adds it to the control.
        /// </summary>
        /// <param name="style">Style for the new marker.</param>
        /// <param name="latitude">Latitude to use for the location.</param>
        /// <param name="longitude">Longitude to center the location.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(MarkerStyle style, double latitude, double longitude)
        {
            return AddMarker(style, new Location(latitude, longitude));
        }
        
        /// <summary>
        /// Creates a new marker and adds it to the control.
        /// </summary>
        /// <param name="locations">Locations for the new marker.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(IEnumerable<Location> locations)
        {
            return AddMarker(
                new Marker
                {
                    Locations = locations
                });
        }

        /// <summary>
        /// Creates a new marker and adds it to the control.
        /// </summary>
        /// <param name="style">Style for the new marker.</param>
        /// <param name="locations">Locations for the new marker.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddMarker(MarkerStyle style, IEnumerable<Location> locations)
        {
            return AddMarker(
                new Marker
                {
                    Style = style,
                    Locations = locations
                });
        }

        /// <summary>
        /// Adds the paths to the control.
        /// </summary>
        /// <param name="paths">Paths to add.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddPaths(IEnumerable<Path> paths)
        {
            foreach (var path in paths)
            {
                _urlBuilder.Paths.Add(path);
            }

            return this;
        }

        /// <summary>
        /// Adds the path to the control.
        /// </summary>
        /// <param name="path">Path to add.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddPath(Path path)
        {
            _urlBuilder.Paths.Add(path);

            return this;
        }

        /// <summary>
        /// Creates a new path and adds it to the control.
        /// </summary>
        /// <param name="style">Style for the new path.</param>
        /// <param name="locations">Locations for the new marker.</param>
        /// <returns></returns>
        public GoogleStaticMapControl AddPath(PathStyle style, IEnumerable<Location> locations)
        {
            return AddPath(
                new Path
                {
                    Style = style,
                    Locations = locations
                });
        }
    }
}