using System.Collections.Generic;

namespace Ofl.YouTube.V3.VideoResource
{
    public class Suggestions
    {
        public IReadOnlyCollection<string>? ProcessingErrors { get; set; }

        public IReadOnlyCollection<string>? ProcessingWarnings { get; set; }

        public IReadOnlyCollection<string>? ProcessingHints { get; set; }

        public IReadOnlyCollection<TagSuggestion>? TagSuggestions { get; set; }

        public IReadOnlyCollection<string>? EditorSuggestions { get; set; }
    }
}
