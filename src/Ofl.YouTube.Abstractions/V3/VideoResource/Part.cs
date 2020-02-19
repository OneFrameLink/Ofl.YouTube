using System;

namespace Ofl.YouTube.V3.VideoResource
{
    [Flags]
    public enum Part
    {
        ContentDetails = 1,
        FileDetails = 2,
        Id = 4,
        LiveStreamingDetails = 8,
        Localizations = 16,
        Player = 32,
        ProcessingDetails = 64,
        RecordingDetails = 128,
        Snippet = 256,
        Statistics = 512,
        Status = 1024,
        Suggestions = 2048,
        TopicDetail = 4096
    }
}
