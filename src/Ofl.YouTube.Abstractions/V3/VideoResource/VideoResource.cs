using System.Collections.Generic;

namespace Ofl.YouTube.V3.VideoResource
{
    public class VideoResource
    {
        public string? Kind { get; set; }

        public string? Etag { get; set; }

        public string? Id { get; set; }

        public Snippet? Snippet { get; set; }

        public ContentDetails? ContentDetails { get; set; }

        public Status? Status { get; set; }

        public Statistics? Statistics { get; set; }

        public Player? Player { get; set; }

        public TopicDetails? TopicDetails { get; set; }

        public RecordingDetails? RecordingDetails { get; set; }

        public FileDetails? FileDetails { get; set; }

        public ProcessingDetails? ProcessingDetails { get; set; }

        public Suggestions? Suggestions { get; set; }

        public LiveStreamingDetails? LiveStreamingDetails { get; set; }

        public IReadOnlyDictionary<string, Localization>? Localizations { get; set; }
    }
}
