using System;
using System.Collections.Generic;
using Ofl.YouTube.V3.VideoResource;

namespace Ofl.YouTube.V3.PlaylistItemResource
{
    public class Snippet
    {
        public DateTimeOffset PublishedAt { get; set; }

        public string? ChannelId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public IReadOnlyDictionary<string, Thumbnail>? Thumbnails { get; set; }

        public string? ChannelTitle { get; set; }

        public string? PlaylistId { get; set; }

        public int Position { get; set; }

        public ResourceId? ResourceId { get; set; }
    }
}
