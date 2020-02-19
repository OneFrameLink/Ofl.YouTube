namespace Ofl.YouTube.V3.VideoResource
{
    public class AudioStream
    {
        public int ChannelCount { get; set; }

        public string? Codec { get; set; }

        public long BitrateBps { get; set; }

        public string? Vendor { get; set; }
    }
}
