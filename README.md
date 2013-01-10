Helpers for ASP.NET MVC for creating map images with the [Google Static Maps
API V2](https://developers.google.com/maps/documentation/staticmaps).


Usage
-----

1. Install the [NuGet package](https://nuget.org/packages/Molimentum.StaticMapHelpers).

2. Add maps to your views:

    @(Html.GoogleStaticMap(320, 200, GoogleMapType.Default)
        .Zoom(10)
        .AddMarker(new MarkerStyle { Label = "A" }, "Whangarei, New Zealand"))

For more examples, see the included Demo project.


Project Home
------------

https://github.com/tischlda/StaticMapHelpers


Copyright
---------

Copyright (c) 2012 - 2013 David Tischler, licensed under the [MIT License](https://raw.github.com/tischlda/StaticMapHelpers/master/MIT-LICENSE.txt).