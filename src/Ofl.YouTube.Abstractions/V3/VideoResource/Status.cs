using System;

namespace Ofl.YouTube.V3.VideoResource
{
    public class Status
    {
        public string? UploadStatus { get; set; }
        public string? FailureReason { get; set; }
        public string? RejectionReason { get; set; }
        public string? PrivacyStatus { get; set; }
        public DateTimeOffset PublishAt { get; set; }
        public string? License { get; set; }
        public bool Embeddable { get; set; }
        public bool PublicStatsViewable { get; set; }
    }
}
