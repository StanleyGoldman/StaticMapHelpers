using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Molimentum.StaticMapHelpers.Tests
{
    public class GoogleStaticMapControlTests
    {
        [Fact]
        public void AsImage_should_create_an_img_tag()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default)
                .AsImage();

            var result = control.ToHtmlString();

            var node = HtmlAgilityPack.HtmlNode.CreateNode(result);
            node.Name.Should().Be("img");
            node.Attributes["width"].Value.Should().Be("320");
            node.Attributes["height"].Value.Should().Be("240");

            var src = node.Attributes["src"].Value;
            src.Should().NotBeNullOrEmpty();
            Uri.IsWellFormedUriString(src, UriKind.Absolute).Should().BeTrue();
            src.ShouldContainQueryParameter("size", "320x240");
        }

        [Fact]
        public void AsUrl_should_create_a_url()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default)
                .AsUrl();

            var result = control.ToHtmlString();

            Uri.IsWellFormedUriString(result, UriKind.Absolute).Should().BeTrue();

            result.ShouldContainQueryParameter("size", "320x240");
        }

        [Fact]
        public void Default_scheme_should_be_http()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default)
                .AsUrl();

            var result = control.ToHtmlString();

            Uri.IsWellFormedUriString(result, UriKind.Absolute).Should().BeTrue();
            result.Should().StartWith("http://");
        }

        [Fact]
        public void UseHttp_should_set_scheme_to_https()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();
            
            control.UseHttps();

            var result = control.ToHtmlString();

            Uri.IsWellFormedUriString(result, UriKind.Absolute).Should().BeTrue();
            result.Should().StartWith("https://");
        }

        [Fact]
        public void UseHttp_with_true_should_set_scheme_to_https()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.UseHttps(true);

            var result = control.ToHtmlString();

            Uri.IsWellFormedUriString(result, UriKind.Absolute).Should().BeTrue();
            result.Should().StartWith("https://");
        }

        [Fact]
        public void UseHttp_with_false_should_set_scheme_to_https()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.UseHttps(false);

            var result = control.ToHtmlString();

            Uri.IsWellFormedUriString(result, UriKind.Absolute).Should().BeTrue();
            result.Should().StartWith("http://");
        }

        [Fact]
        public void Default_sensor_should_be_false()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("sensor", "false");
        }

        [Fact]
        public void UsingSensor_should_set_sensor_to_true()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.UsingSensor();

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("sensor", "true");
        }

        [Fact]
        public void UsingSensor_with_true_should_set_sensor_to_true()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.UsingSensor(true);

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("sensor", "true");
        }

        [Fact]
        public void UsingSensor_with_false_should_set_sensor_to_false()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.UsingSensor(false);

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("sensor", "false");
        }

        [Fact]
        public void Default_center_should_be_none()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            var result = control.ToHtmlString();

            result.ShouldNotContainQueryParameter("center");
        }

        [Fact]
        public void CenterOn_with_Location_with_address_should_set_location()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.CenterOn(new Location("My Location"));

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("center", "My Location");
        }

        [Fact]
        public void CenterOn_with_Location_with_lat_lon_should_set_location()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.CenterOn(new Location(23.45, -42.10));

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("center", "23.45,-42.1");
        }

        [Fact]
        public void CenterOn_with_address_should_set_location()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.CenterOn("My Location");

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("center", "My Location");
        }

        [Fact]
        public void CenterOn_with_lat_lon_should_set_location()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.CenterOn(23.45, -42.10);

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("center", "23.45,-42.1");
        }

        [Fact]
        public void Default_zoom_should_be_none()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            var result = control.ToHtmlString();

            result.ShouldNotContainQueryParameter("zoom");
        }

        [Fact]
        public void Zoom_should_set_zoom()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.Zoom(6);

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("zoom", "6");
        }

        [Fact]
        public void Default_scale_should_be_none()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            var result = control.ToHtmlString();

            result.ShouldNotContainQueryParameter("scale");
        }

        [Fact]
        public void Scale_should_set_scale()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.Scale(1);

            var result = control.ToHtmlString();

            result.ShouldContainQueryParameter("scale", "1");
        }

        [Fact]
        public void Default_markers_should_be_none()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            var result = control.ToHtmlString();

            result.ShouldNotContainQueryParameter("markers");
        }

        [Fact]
        public void Adding_markers_should_add_markers_parameters()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();
            
            control.AddMarker(
                new MapMarkerStyle {
                    Color = "red",
                    Icon = "http://test/test1.png",
                    Label = "A",
                    Size = MapMarkerSize.Small,
                    Shadow = false
                },
                new[] { new Location("My Location 1"), new Location("My Location 2") }
            );
            control.AddMarker(
                new MapMarkerStyle {
                    Color = "green",
                    Icon = "http://test/test2.png",
                    Label = "B",
                    Size = MapMarkerSize.Tiny
                },
                new[] { new Location("My Location 3"), new Location("My Location 4") }
            );
    
            var result = control.ToHtmlString();

            var expected = new [] {
                new[] {
                    "color:red",
                    "icon:http://test/test1.png",
                    "label:A",
                    "size:small",
                    "shadow:false",
                    "My Location 1",
                    "My Location 2"
                },
                new[] {
                    "color:green",
                    "icon:http://test/test2.png",
                    "label:B",
                    "size:tiny",
                    "My Location 3",
                    "My Location 4"
                }
            };

            result
                .GetQueryParameters()
                .GetValues("markers")
                .Select(value =>
                    // split each entry into items, order them, and join again to a string
                    String.Join("|", value.Split(new[] { '|' }).OrderBy(s => s)))
                .Should().BeEquivalentTo(
                    // sort and combine the expected results to match result format
                    expected.Select(value => String.Join("|", value.OrderBy(s => s))));
        }

        [Fact]
        public void Default_path_should_be_none()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            var result = control.ToHtmlString();

            result.ShouldNotContainQueryParameter("path");
        }

        [Fact]
        public void Adding_paths_should_add_path_parameters()
        {
            var control = new GoogleStaticMapControl(320, 240, GoogleMapType.Default).AsUrl();

            control.AddPath(
                new MapPathStyle {
                    Color = "red",
                    FillColor = "green",
                    Weight = 1
                },
                new[] { new Location("My Location 1"), new Location("My Location 2") }
            );

            control.AddPath(
                new MapPathStyle
                {
                    Color = "blue",
                    FillColor = "yellow"
                },
                new[] { new Location("My Location 3"), new Location("My Location 4") }
            );

            var result = control.ToHtmlString();

            var expected = new[] {
                new[] {
                    "color:red",
                    "fillcolor:green",
                    "weight:1",
                    "My Location 1",
                    "My Location 2"
                },
               new[] {
                    "color:blue",
                    "fillcolor:yellow",
                    "My Location 3",
                    "My Location 4"
                }
            };

            result
                .GetQueryParameters()
                .GetValues("path")
                .Select(value =>
                    // split each entry into items, order them, and join again to a string
                    String.Join("|", value.Split(new[] { '|' }).OrderBy(s => s)))
                .Should().BeEquivalentTo(
                // sort and combine the expected results to match result format
                    expected.Select(value => String.Join("|", value.OrderBy(s => s))));
        }
    }
}
