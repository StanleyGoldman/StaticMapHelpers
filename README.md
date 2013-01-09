Helpers for ASP.NET MVC for creating map images with the Google Static Maps
API V2.

https://developers.google.com/maps/documentation/staticmaps

Usage
-----

1. Install the NuGet package

2. Add maps to your views:

	@(Html.GoogleStaticMap(320, 200, GoogleMapType.Default)
		.Zoom(10)
		.AddMarker(new MarkerStyle { Label = "A" }, "Whangarei, New Zealand"))

For more examples, see the included Demo project.

Copyright
---------

Copyright (c) 2012 David Tischler, licensed under the MIT License.