using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Ofl.Net.Http.ApiClient.Json;
using Ofl.Threading.Tasks;
using Ofl.YouTube.V3.PlaylistItemResource;
using Ofl.YouTube.V3.VideoResource;

namespace Ofl.YouTube.V3
{
    public class YouTubeClient : JsonApiClient, IYouTubeClient
    {
        #region Constructor

        public YouTubeClient(HttpClient httpClient) : base(httpClient)
        { }

        #endregion

        #region Overrides

        protected override ValueTask<string> FormatUrlAsync(string url, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            // The url.
            url = $"https://www.googleapis.com/youtube/v3/{ url }";

            // Return the url.
            return ValueTaskExtensions.FromResult(url);
        }

        #endregion

        #region Implementation of IYouTubeClient

        public Task<VideoListResponse> GetVideosAsync(VideoListRequest request, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // The URL.
            // Documentation: https://developers.google.com/youtube/v3/docs/videos/list
            var url = "videos";

            // Append items in the request.
            url = QueryHelpers.AddQueryString(url, "id", request.Ids.Join(","));
            url = QueryHelpers.AddQueryString(url, "part", request.Parts.GetPartsParameter());
            if (request.MaxResults != null) url = QueryHelpers.AddQueryString(url, "maxResults", request.MaxResults.Value.ToString(CultureInfo.InvariantCulture));
            if (!string.IsNullOrWhiteSpace(request.PageToken)) url = QueryHelpers.AddQueryString(url, "pageToken", request.PageToken);

            // Get JSON from the client factory.
            return GetAsync<VideoListResponse>(url, cancellationToken);
        }

        public Task<PlaylistItemListResponse> GetPlaylistItemsAsync(PlaylistItemListRequest request,
            CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // The URL.
            // Documentation: https://developers.google.com/youtube/v3/docs/playlistItems/list
            var url = "playlistItems";

            // Append items in the request.
            url = QueryHelpers.AddQueryString(url, "playlistId", request.PlaylistId);
            url = QueryHelpers.AddQueryString(url, "part", request.Parts.GetPartsParameter());
            if (request.MaxResults != null) url = QueryHelpers.AddQueryString(url, "maxResults", request.MaxResults.Value.ToString(CultureInfo.InvariantCulture));
            if (!string.IsNullOrWhiteSpace(request.PageToken)) url = QueryHelpers.AddQueryString(url, "pageToken", request.PageToken);

            // Get JSON from the client factory.
            return GetAsync<PlaylistItemListResponse>(url, cancellationToken);
        }


        #endregion
    }
}
