using System;
using System.Collections.Specialized;
using System.Web;
using FluentAssertions;

namespace Molimentum.StaticMapHelpers.Tests
{
    public static class AssertionExtensions
    {
        public static void ShouldContainQueryParameter(this string urlString, string name, string value)
        {
            GetQueryParameters(urlString)[name].Should().Be(value);
        }

        public static void ShouldNotContainQueryParameter(this string urlString, string name)
        {
            GetQueryParameters(urlString)[name].Should().BeNull();
        }

        public static NameValueCollection GetQueryParameters(this string urlString)
        {
            var url = new Uri(urlString);

            return HttpUtility.ParseQueryString(url.Query);
        }
    }
}
