using System;
using System.Collections.Generic;

namespace Ofl.YouTube.V3.VideoResource
{
    public class Snippet
    {
        public DateTimeOffset PublishedAt { get; set; }

        public string? ChannelId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public IReadOnlyDictionary<string, Thumbnail>? Thumbnails { get; set; }

        public string? ChannelTitle { get; set; }

        public IReadOnlyCollection<string>? Tags { get; set; }

        public string? CategoryId { get; set; }

        public string? LiveBroadcastContent { get; set; }

        public string? DefaultLanguage { get; set; }

        public Localization? Localized { get; set; }

        public string? DefaultAudioLanguage { get; set; }
    }
}
