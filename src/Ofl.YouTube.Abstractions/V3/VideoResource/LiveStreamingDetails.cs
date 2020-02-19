using System;

namespace Ofl.YouTube.V3.VideoResource
{
    public class LiveStreamingDetails
    {
        public DateTimeOffset ActualStartTime { get; set; }

        public DateTimeOffset ActualEndTime { get; set; }

        public DateTimeOffset ScheduledStartTime { get; set; }

        public DateTimeOffset ScheduledEndTime { get; set; }

        public long ConcurrentViewers { get; set; }

        public string? ActiveChatId { get; set; }
    }
}
