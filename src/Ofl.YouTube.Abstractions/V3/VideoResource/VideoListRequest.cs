using System;
using System.Collections.Generic;
using System.Linq;
using Ofl.Linq;

namespace Ofl.YouTube.V3.VideoResource
{
    public class VideoListRequest
    {
        #region Constructor

        public VideoListRequest(
            IEnumerable<string>? ids = null,
            IEnumerable<Part>? parts = null,
            int? maxResults = null,
            string? pageToken = null
        )
        {
            // Validate parameters.
            if (maxResults != null && maxResults <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxResults), maxResults.Value,
                    $"The {nameof(maxResults)} parameter must be a positive value.");

            // Assign values.
            Ids = (ids ?? Enumerable.Empty<string>()).ToReadOnlyCollection();
            Parts = (parts ?? Enumerable.Empty<Part>()).ToReadOnlyCollection();
            MaxResults = maxResults;
            PageToken = pageToken;
        }

        #endregion

        #region Instance, read-only state

        public IReadOnlyCollection<Part> Parts { get; }

        public IReadOnlyCollection<string> Ids { get; }

        public string? PageToken { get; }

        public int? MaxResults { get; }

        #endregion
    }
}
