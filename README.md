Helpers for ASP.NET MVC for creating map images with the Google Static Maps
API V2.

https://developers.google.com/maps/documentation/staticmaps

	@(Html.GoogleStaticMap(320, 200, GoogleMapType.Satellite)
		.Zoom(5)
		.AddMarker(new MarkerStyle { Icon = "http://chart.googleapis.com/chart?chst=d_simple_text_icon_below&chld=%7C12%7Cff0000%7Clocation%7C12%7Cff0000" }, new[] { new Location("Whangarei, New Zealand"), new Location("Auckland, New Zealand") })
		.AddPath(new PathStyle { Color = "green" }, new[] { new Location("Whangarei, New Zealand"), new Location("Auckland, New Zealand") }))

For a few more examples, see the included Demo project.

Copyright
---------

Copyright (c) 2012 David Tischler, licensed under the MIT License.