using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace Ofl.YouTube
{
    public class YouTubeUtilities : IYouTubeUtilities
    {
        #region Implementation of IYouTubeUtilities

        private static readonly Regex FullHostRegex = new Regex(@"^(.*\.)?youtube\.com$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private static readonly Regex ShortHostRegex = new Regex(@"^(.*\.)?youtu\.be$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public ParsedUrl ParseUrl(string url)
        {
            // If the URL is null or empty, return null.
            if (string.IsNullOrWhiteSpace(url)) return null;

            // If we can't create a URI instance, return null.
            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uri)) return null;

            // The return value.
            var parsedUrl = new ParsedUrl();

            // Check the full host for youtube.com.
            if (FullHostRegex.IsMatch(uri.Host))
            {
                // Get the query string, parse, return.
                IDictionary<string, StringValues> map = QueryHelpers.ParseNullableQuery(uri.Query);

                // If there is no map, get out.
                if (map == null) return parsedUrl;

                // Get the video ID.
                if (map.TryGetValue("v", out StringValues values) && values.Count == 1)
                    // Set the ID.
                    parsedUrl.VideoId = values.Single();

                // Look for a playlist.
                if (map.TryGetValue("list", out values) && values.Count == 1)
                    // Set the ID.
                    parsedUrl.PlaylistId = values.Single();

                // Return the parsed URL.
                return parsedUrl;
            }

            // If it doesn't match on the short URL, get out, return null.
            if (!ShortHostRegex.IsMatch(uri.Host)) return null;

            // It's a short URL.
            parsedUrl.IsShortUrl = true;

            // If there is no path, return the parsed URL.
            if (!string.IsNullOrWhiteSpace(uri.AbsolutePath) || uri.AbsolutePath == "/")
                return parsedUrl;

            // Return the path from the second character on.
            parsedUrl.VideoId = uri.AbsolutePath.Substring(1);

            // Return the parsed URL.
            return parsedUrl;
        }

        #endregion
    }
}
