using System;
using System.Collections.Generic;

namespace Ofl.YouTube.V3.PlaylistItemResource
{
    public class PlaylistItemListRequest
    {
        #region Constructor

        public PlaylistItemListRequest(
            string playlistId,
            IReadOnlyCollection<Part> parts,
            int? maxResults,
            string? pageToken
        )
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(playlistId)) 
                throw new ArgumentNullException(nameof(playlistId));
            if (parts == null) throw new ArgumentNullException(nameof(parts));
            if (maxResults != null && maxResults <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxResults), maxResults.Value,
                    $"The {nameof(maxResults)} parameter must be a positive value.");

            // Assign values.
            PlaylistId = playlistId;
            Parts = parts;
            MaxResults = maxResults;
            PageToken = pageToken;
        }

        #endregion

        #region Instance, read-only state.

        public IReadOnlyCollection<Part> Parts { get; }

        public string PlaylistId { get; set; }

        public string? PageToken { get; set; }

        public int? MaxResults { get; set; }

        #endregion
    }
}
