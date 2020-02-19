using System;
using Ofl.YouTube;
using Xunit;

namespace Ofl.Youtube.Extensions.Tests
{
    public class YouTubeExtensionsTests
    {
        [Theory]
        [InlineData("https://www.google.com")]
        [InlineData("https://www.youtube.com")]
        [InlineData("https://www.youtube.com/watch")]
        [InlineData("https://www.youtube.com/watch?v=")]
        [InlineData("https://www.youtube.com/playlist")]
        [InlineData("https://www.youtube.com/playlist?list=")]
        public void Test_ParseUrl_Null(string url)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            // Parse the URL.
            ParsedUrl? actual = YouTubeExtensions.ParseUrl(url);

            // Null.
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("https://www.youtube.com/watch?v=5bkW0TWGYVQ", "5bkW0TWGYVQ", null, false)]
        [InlineData("https://www.youtube.com/watch?v=jz_7xVHZHOg&list=WL&index=3&t=0s", "jz_7xVHZHOg", null, false)]
        [InlineData("https://www.youtube.com/watch?v=Iz_zmUe8Gt8&list=PLqOEDroJnZHxjytQ9SISzr5dpw49yHHsb&index=2&t=0s", "Iz_zmUe8Gt8", null, false)]
        [InlineData("https://www.youtube.com/playlist?list=PLqOEDroJnZHxjytQ9SISzr5dpw49yHHsb", null, "PLqOEDroJnZHxjytQ9SISzr5dpw49yHHsb", false)]
        [InlineData("https://youtu.be/57kbSBLahU0", "57kbSBLahU0", null, true)]
        
        public void Test_ParseUrl_NonNull(string url, string? videoId, string? playlistId, bool isShortUrl)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            // Parse the URL.
            ParsedUrl? actual = YouTubeExtensions.ParseUrl(url);

            // Not null.
            Assert.NotNull(actual);

            // Assert.
            Assert.Equal(videoId, actual!.VideoId);
            Assert.Equal(playlistId, actual!.PlaylistId);
            Assert.Equal(isShortUrl, actual!.IsShortUrl);
        }
    }
}
