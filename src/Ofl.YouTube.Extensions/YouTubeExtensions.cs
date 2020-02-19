using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace Ofl.YouTube
{
    public static class YouTubeExtensions
    {
        #region Implementation of IYouTubeUtilities

        private static readonly Regex FullHostRegex = new Regex(@"^(.*\.)?youtube\.com$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private static readonly Regex ShortHostRegex = new Regex(@"^(.*\.)?youtu\.be$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static ParsedUrl? ParseUrl(string url)
        {
            // If the URL is null or empty, return null.
            if (string.IsNullOrWhiteSpace(url)) return null;

            // If we can't create a URI instance, return null.
            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uri)) return null;

            // Check the full host for youtube.com.
            if (FullHostRegex.IsMatch(uri.Host))
            {
                // Get the query string, parse, return.
                IDictionary<string, StringValues> map = QueryHelpers.ParseNullableQuery(uri.Query);

                // If there is no map, return null.
                if (map == null) return null;

                // Get the video ID.
                // Use if not null or empty.
                if (
                    map.TryGetValue("v", out StringValues values)
                    && values.Count == 1
                    && !string.IsNullOrWhiteSpace(values.Single())
                )
                    // Return from an ID.
                    return ParsedUrl.FromVideoId(values.Single());

                // Look for a playlist.
                if (
                        map.TryGetValue("list", out values)
                        && values.Count == 1
                        && !string.IsNullOrWhiteSpace(values.Single())
                    )
                    // Return from a playlist.
                    return ParsedUrl.FromPlaylistId(values.Single());

                // We couldn't find anything, get out.
                return null;
            }

            // If it doesn't match on the short URL, get out, return null.
            if (!ShortHostRegex.IsMatch(uri.Host)) return null;

            // If there is no path, return null.
            if (string.IsNullOrWhiteSpace(uri.AbsolutePath) || uri.AbsolutePath == "/")
                return null;

            // Return a shortened URL.
            return ParsedUrl.FromVideoId(uri.AbsolutePath.Substring(1), true);
        }

        #endregion
    }
}