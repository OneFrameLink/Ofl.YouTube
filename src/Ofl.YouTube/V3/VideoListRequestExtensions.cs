using System;
using System.Collections.Generic;
using Ofl.YouTube.V3.VideoResource;

namespace Ofl.YouTube.V3
{
    public static class VideoListRequestExtensions
    {
        public static VideoListRequest SetParts(
            this VideoListRequest request, 
            params Part[] parts
        )
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (parts == null) throw new ArgumentNullException(nameof(parts));

            // Call the overload.
            return request.SetParts((IEnumerable<Part>)parts);
        }

        public static VideoListRequest SetParts(
            this VideoListRequest request, 
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
