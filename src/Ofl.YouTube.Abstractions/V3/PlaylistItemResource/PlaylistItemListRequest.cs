using Ofl.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofl.YouTube.V3.PlaylistItemResource
{
    public class PlaylistItemListRequest
    {
        #region Constructor

        public PlaylistItemListRequest(
            string playlistId,
            IEnumerable<Part>? parts = null,
            int? maxResults = null,
            string? pageToken = null
        )
        {
            // Validate parameters.
            PlaylistId = string.IsNullOrWhiteSpace(playlistId)
                ? throw new ArgumentNullException(nameof(playlistId))
                : playlistId;
            if (maxResults != null && maxResults <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxResults), maxResults.Value,
                    $"The {nameof(maxResults)} parameter must be a positive value.");

            // Assign values.
            PlaylistId = playlistId;
            Parts = (parts ?? Enumerable.Empty<Part>()).ToReadOnlyCollection();
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
