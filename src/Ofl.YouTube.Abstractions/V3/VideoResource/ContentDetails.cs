using Ofl.Text.Json;
using System;
using System.Text.Json.Serialization;

namespace Ofl.YouTube.V3.VideoResource
{
    public class ContentDetails
    {
        [JsonConverter(typeof(Iso8601DurationTimeSpanJsonConverter))]
        public TimeSpan Duration { get; set; }

        public string? Dimension { get; set; }
        public string? Definition { get; set; }
        [JsonConverter(typeof(BooleanStringJsonConverter))]
        public bool Caption { get; set; }
        public bool LicensedContent { get; set; }
        public RegionRestriction? RegionRestriction { get; set; }
        public ContentRating? ContentRating { get; set; }
        public string? Projection { get; set; }
        public bool HasCustomThumbnail { get; set; }
    }
}
