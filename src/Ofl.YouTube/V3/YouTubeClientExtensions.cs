using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ofl.Collections.Generic;
using Ofl.YouTube.V3.PlaylistItemResource;

namespace Ofl.YouTube.V3
{
    public static class YouTubeClientExtensions
    {
        public static async Task<IReadOnlyCollection<PlaylistItemResource.PlaylistItemResource>> GetAllPlaylistItemsAsync(this IYouTubeClient client,
            PlaylistItemListRequest request, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (request == null) throw new ArgumentNullException(nameof(request));

            // The response.
            PlaylistItemListResponse response = null;

            // The items.
            var items = new List<PlaylistItemResource.PlaylistItemResource>();

            // Cycle once.
            do
            {
                // Create a new request.
                var newRequest = new PlaylistItemListRequest {
                    MaxResults = MaxResults.MaxValue,
                    PageToken = response?.NextPageToken,
                    PlaylistId = request.PlaylistId
                }.SetParts(request.Parts);

                // Make the request.
                response = await client.GetPlaylistItemsAsync(newRequest, cancellationToken).ConfigureAwait(false);

                // Append.
                items.AddRange(response.Items);
            } while (!string.IsNullOrWhiteSpace(response.NextPageToken));

            // Wrap the result and return.
            return items.WrapInReadOnlyCollection();
        }
    }
}
