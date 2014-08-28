using System;
using System.Collections.Generic;

namespace Molimentum.StaticMapHelpers
{
    /// <summary>
    /// Builder for creating urls for the Google Static Map API V2.
    /// </summary>
    public class GoogleStaticMapUrlBuilder
    {
        private const string _baseUrlHttp = "http://maps.googleapis.com/maps/api/staticmap";
        private const string _baseUrlHttps = "https://maps.googleapis.com/maps/api/staticmap";

        /// <summary>
        /// Initializes the url builder.
        /// </summary>
        /// <param name="width">Width of the map in pixels.</param>
        /// <param name="height">Height of the map in pixels.</param>
        /// <param name="mapType">Type of the map.</param>
        public GoogleStaticMapUrlBuilder(int width, int height, GoogleMapType mapType)
        {
            Width = width;
            Height = height;
            MapType = mapType;

            Markers = new List<MapMarker>();
            Paths = new List<MapPath>();
        }

        /// <summary>
        /// Width of the map in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the map in pixels.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Type of the map.
        /// </summary>
        public GoogleMapType MapType { get; set; }

        /// <summary>
        /// Markers to draw on the map.
        /// </summary>
        public ICollection<MapMarker> Markers { get; private set; }

        /// <summary>
        /// Paths to draw on the map.
        /// </summary>
        public ICollection<MapPath> Paths { get; private set; }

        /// <summary>
        /// Sensor usage, see
        /// https://developers.google.com/maps/documentation/staticmaps/
        /// for details.
        /// </summary>
        public bool UsingSensor { get; set; }

        /// <summary>
        /// When <c>true</c>, an https url is created,
        /// if <c>false</c> an http url.
        /// </summary>
        public bool UseHttps { get; set; }

        /// <summary>
        /// The zoom level of the map, see
        /// https://developers.google.com/maps/documentation/staticmaps/
        /// for details.
        /// </summary>
        public int?  Zoom { get; set; }

        /// <summary>
        /// The scale for the image, see
        /// https://developers.google.com/maps/documentation/staticmaps/
        /// for details.
        /// </summary>
        public int? Scale { get; set; }

        /// <summary>
        /// The center of the map.
        /// </summary>
        public Location Center { get; set; }

        public string UsingKey { get; set; }

        /// <summary>
        /// Creates the url with the settings that have been
        /// specified before.
        /// </summary>
        /// <returns>String containing a url.</returns>
        public override string ToString()
        {
            return CreateImageUrl();
        }

        /// <summary>
        /// Creates the url with the settings that have been
        /// specified before.
        /// </summary>
        /// <returns>String containing a url.</returns>
        protected string CreateImageUrl()
        {
            var parameters = new ParameterListBuilder("=", "&");

            parameters.Add("size", String.Format("{0}x{1}", Width, Height));
            parameters.Add("sensor", UsingSensor ? "true" : "false");
            if (MapType != GoogleMapType.Default) parameters.Add("maptype", MapType.ToString().ToLower());
            if (Zoom != null) parameters.Add("zoom", Zoom.ToString());
            if (Scale != null) parameters.Add("scale", Scale.ToString());
            if (Center != null) parameters.Add("center", Center.ToString());

            foreach (var marker in Markers) parameters.Add("markers", CreateMarkerParameters(marker), false);
            foreach (var path in Paths) parameters.Add("path", CreatePathParameters(path), false);

            if (UsingKey != null) parameters.Add("key", UsingKey);

            return String.Format("{0}?{1}",
                UseHttps ? _baseUrlHttps : _baseUrlHttp,
                String.Join("&", parameters));
        }

        /// <summary>
        /// Creates the request parameters for the given marker.
        /// </summary>
        /// <param name="marker">Marker to create request parameters for.</param>
        /// <returns>Request parameters for the given marker.</returns>
        protected static string CreateMarkerParameters(MapMarker marker)
        {
            var parameters = new ParameterListBuilder(":", "|");

            if (marker.Style != null)
            {
                if (marker.Style.Color != null) parameters.Add("color", marker.Style.Color.ToLower());
                if (marker.Style.Icon != null) parameters.Add("icon", marker.Style.Icon);
                if (marker.Style.Label != null) parameters.Add("label", marker.Style.Label);
                if (marker.Style.Size != MapMarkerSize.Default) parameters.Add("size", marker.Style.Size.ToString().ToLower());
                if (!marker.Style.Shadow) parameters.Add("shadow", "false");
            }

            foreach (var location in marker.Locations) parameters.Add(location.ToString());

            return parameters.ToString();
        }

        /// <summary>
        /// Creates the request parameters for the given path.
        /// </summary>
        /// <param name="path">Path to create request parameters for.</param>
        /// <returns>Request parameters for the given path.</returns>
        protected static string CreatePathParameters(MapPath path)
        {
            var parameters = new ParameterListBuilder(":", "|");

            if (path.Style != null)
            {
                if (path.Style.Weight != null) parameters.Add("weight", path.Style.Weight.ToString());
                if (path.Style.Color != null) parameters.Add("color", path.Style.Color.ToLower());
                if (path.Style.FillColor != null) parameters.Add("fillcolor", path.Style.FillColor.ToLower());
            }

            foreach (var location in path.Locations) parameters.Add(location.ToString());

            return parameters.ToString();
        }
    }
}
