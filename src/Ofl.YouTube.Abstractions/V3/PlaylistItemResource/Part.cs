using System;

namespace Ofl.YouTube.V3.PlaylistItemResource
{
    [Flags]
    public enum Part
    {
        ContentDetails = 1,
        Id = 2,
        Snippet = 4,
        Status = 8
    }
}
