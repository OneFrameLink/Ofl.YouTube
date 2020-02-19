using System.Collections.Generic;

namespace Ofl.YouTube.V3.VideoResource
{
    public class TagSuggestion
    {
        public string? Tag { get; set; }

        public IReadOnlyCollection<string>? CategoryRestricts { get; set; }
    }
}
