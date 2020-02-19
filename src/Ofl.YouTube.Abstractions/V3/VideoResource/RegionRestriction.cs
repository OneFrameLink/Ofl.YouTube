using System.Collections.Generic;

namespace Ofl.YouTube.V3.VideoResource
{

    public class RegionRestriction
    {
        public IReadOnlyCollection<string>? Allowed { get; set; }

        public IReadOnlyCollection<string>? Blocked { get; set; }
    }
}
