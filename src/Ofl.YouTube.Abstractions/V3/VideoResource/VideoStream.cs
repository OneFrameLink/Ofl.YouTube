namespace Ofl.YouTube.V3.VideoResource
{
    public class VideoStream
    {
        public int WidthPixels { get; set; }

        public int HeightPixels { get; set; }

        public decimal FrameRateFps { get; set; }

        public decimal AspectRatio { get; set; }

        public string? Codec { get; set; }

        public long BitrateBps { get; set; }

        public string? Rotation { get; set; }

        public string? Vendor { get; set; }
    }
}
