using System;
using System.Collections.Generic;
using System.Linq;
using Ofl.Linq;

namespace Ofl.YouTube.V3.VideoResource
{
    public static class VideoListRequestExtensions
    {
        public static VideoListRequest With(
            this VideoListRequest request,
            IReadOnlyCollection<string>? ids = null,
            IReadOnlyCollection<Part>? parts = null,
            int? maxResults = null,
            string? pageToken = null
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Copy over.
            return new VideoListRequest(
                ids ?? request.Ids,
                parts ?? request.Parts,
                maxResults ?? request.MaxResults,
                pageToken ?? request.PageToken
            );
        }

        public static VideoListRequest AddParts(
            this VideoListRequest request,
            params Part[] parts
        ) => request.AddParts(parts.AsEnumerable());

        public static VideoListRequest AddParts(
            this VideoListRequest request,
            IEnumerable<Part> parts
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (parts == null) throw new ArgumentNullException(nameof(parts));
            
            // Sub.
            return request.With(parts:
                request.Parts.Concat(parts).Distinct().ToReadOnlyCollection()
            );
        }

        public static VideoListRequest AddIds(
            this VideoListRequest request,
            params string[] ids
        ) => request.AddIds(ids.AsEnumerable());

        public static VideoListRequest AddIds(
            this VideoListRequest request,
            IEnumerable<string> ids
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (ids == null) throw new ArgumentNullException(nameof(ids));

            // Return with.
            return request.With(request.Ids.Concat(ids).Distinct().ToReadOnlyCollection());
        }
    }
}
