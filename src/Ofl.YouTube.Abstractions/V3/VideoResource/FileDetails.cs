using System;
using System.Collections.Generic;

namespace Ofl.YouTube.V3.VideoResource
{
    public class FileDetails
    {
        public string? FileName { get; set; }

        public long FileSize { get; set; }

        public string? FileType { get; set; }

        public string? Container { get; set; }

        public IReadOnlyCollection<VideoStream>? VideoStreams { get; set; }

        public IReadOnlyCollection<AudioStream>? AudioStreams { get; set; }

        public long DurationMs { get; set; }

        public long BitrateBps { get; set; }

        public DateTimeOffset CreationTime { get; set; }
    }
}
