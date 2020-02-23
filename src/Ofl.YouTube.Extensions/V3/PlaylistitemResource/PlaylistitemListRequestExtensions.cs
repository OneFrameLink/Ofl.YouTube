using System;
using System.Collections.Generic;
using System.Linq;
using Ofl.Linq;

namespace Ofl.YouTube.V3.PlaylistItemResource
{
    public static class PlaylistitemListRequestExtensions
    {
        public static PlaylistItemListRequest With(
            this PlaylistItemListRequest request,
            string? playlistId = null,
            IEnumerable<Part>? parts = null,
            int? maxResults = null,
            string? pageToken = null
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Copy over.
            return new PlaylistItemListRequest(
                string.IsNullOrWhiteSpace(playlistId)
                    ? request.PlaylistId
                    : playlistId,
                parts ?? request.Parts,
                maxResults ?? request.MaxResults,
                pageToken ?? request.PageToken
            );
        }

        public static PlaylistItemListRequest AddParts(
            this PlaylistItemListRequest request,
            params Part[] parts
        ) => request.AddParts(parts.AsEnumerable());

        public static PlaylistItemListRequest AddParts(
            this PlaylistItemListRequest request,
            IEnumerable<Part> parts
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (parts == null) throw new ArgumentNullException(nameof(parts));

            // Get the new list of parts.
            IReadOnlyCollection<Part> newParts = request.Parts
                .Concat(parts)
                .Distinct()
                .ToReadOnlyCollection();

            // Copy over.
            return request.With(parts: newParts);
        }
    }
}
