using Ofl.YouTube.V3.PlaylistItemResource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.YouTube.V3
{
    public static class YouTubeClientExtensions
    {
        public static async Task<ReadOnlyCollection<PlaylistItemResource.PlaylistItemResource>> GetAllPlaylistItemsAsync(
            this IYouTubeClient client,
            PlaylistItemListRequest request, 
            CancellationToken cancellationToken
        )
        {
            // Validate parameters.
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (request == null) throw new ArgumentNullException(nameof(request));

            // The response.
            PlaylistItemListResponse? response = null;

            // The items.
            var items = new List<PlaylistItemResource.PlaylistItemResource>();

            // Cycle once.
            do
            {
                // Create a new request.
                var newRequest = new PlaylistItemListRequest(
                    request.PlaylistId,
                    maxResults: MaxResults.MaxValue,
                    pageToken: response?.NextPageToken
                ).AddParts(request.Parts);

                // Make the request.
                response = await client.GetPlaylistItemsAsync(newRequest, cancellationToken).ConfigureAwait(false);

                // Append.
                items.AddRange(response.Items);
            } while (!string.IsNullOrWhiteSpace(response.NextPageToken));

            // Wrap the result and return.
            return new ReadOnlyCollection<PlaylistItemResource.PlaylistItemResource>(items);
        }
    }
}
