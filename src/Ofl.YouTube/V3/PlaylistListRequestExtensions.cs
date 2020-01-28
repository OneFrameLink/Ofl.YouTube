using System;
using System.Collections.Generic;
using Ofl.YouTube.V3.PlaylistItemResource;

namespace Ofl.YouTube.V3
{
    public static class PlaylistListRequestExtensions
    {
        public static PlaylistItemListRequest SetParts(
            this PlaylistItemListRequest request, 
            params Part[] parts
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (parts == null) throw new ArgumentNullException(nameof(parts));

            // Call the overload.
            return request.SetParts((IEnumerable<Part>) parts);
        }

        public static PlaylistItemListRequest SetParts(
            this PlaylistItemListRequest request, 
            IEnumerable<Part> parts
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (parts == null) throw new ArgumentNullException(nameof(parts));

            // Cycle through and add the parts.
            foreach (Part part in parts)
                request.Parts.Add(part);

            // Return the request.
            return request;
        }
    }
}
