using System;
using System.Threading;
using System.Threading.Tasks;
using Ofl.YouTube.V3;
using Ofl.YouTube.V3.PlaylistItemResource;
using Ofl.YouTube.V3.VideoResource;
using Xunit;

namespace Ofl.YouTube.Tests.V3
{
    public class YouTubeClientTests : IClassFixture<YouTubeClientTestsFixture>
    {
        #region Constructor

        public YouTubeClientTests(YouTubeClientTestsFixture fixture)
        {
            // Validate parameters.
            _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        #endregion

        #region Instance, read-only state.

        private readonly YouTubeClientTestsFixture _fixture;

        #endregion

        #region Helpers

        private IYouTubeClient CreateYouTubeClient() => _fixture.CreateYouTubeClient();

        #endregion

        #region Tests

        [Theory]
        [InlineData("fFoLbsA5Sx0")]
        public async Task Test_GetVideos_Async(string videoId)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(videoId)) throw new ArgumentNullException(nameof(videoId));
            
            // Create the youtube client.
            var youTubeClient = CreateYouTubeClient();

            // Create the request.
            var request = new VideoListRequest()
                .AddIds(videoId)
                .AddParts(YouTube.V3.VideoResource.Part.Id);

            // Make the call.
            await youTubeClient.GetVideosAsync(request, CancellationToken.None).ConfigureAwait(false);
        }

        [Theory]
        [InlineData("PLnJYUs2wpsOLCmkW_YVCgPzCcF2mtt2Km")]
        public async Task Test_GetPlaylistItemsAsync_Async(string playlistId)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(playlistId)) throw new ArgumentNullException(nameof(playlistId));

            // Create the youtube client.
            var youTubeClient = CreateYouTubeClient();

            // Create the request.
            var request = new PlaylistItemListRequest(
                playlistId,
                new[] { YouTube.V3.PlaylistItemResource.Part.Id },
                null,
                null
            );

            // Make the call.
            PlaylistItemListResponse response = await youTubeClient
                .GetPlaylistItemsAsync(request, CancellationToken.None)
                .ConfigureAwait(false);

            // Validate
            Assert.NotNull(response.Items);
            Assert.NotEmpty(response.Items);
        }

        #endregion
    }
}
