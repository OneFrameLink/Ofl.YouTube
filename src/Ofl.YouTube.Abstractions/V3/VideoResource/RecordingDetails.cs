using System;

namespace Ofl.YouTube.V3.VideoResource
{
    public class RecordingDetails
    {
        public string? LocationDescription { get;  set; }
        public RecordingDetailsLocation? Location { get;  set; }
        public DateTimeOffset? RecordingDate { get;  set; }
    }
}
