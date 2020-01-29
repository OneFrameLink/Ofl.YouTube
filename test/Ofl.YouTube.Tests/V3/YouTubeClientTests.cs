using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ofl.Google;
using Ofl.YouTube.V3;
using Ofl.YouTube.V3.VideoResource;
using Xunit;

namespace Ofl.YouTube.Tests.V3
{
    public class YouTubeClientTests
    {
        #region Helpers

        private static IConfigurationRoot CreateConfigurationRoot() => new ConfigurationBuilder()
            // For local debugging.
            .AddJsonFile("appsettings.local.json")
            // For Appveyor.
            .AddEnvironmentVariables()
            .Build();

        private static IYouTubeClient CreateYouTubeClient()
        {
            // Get the configuration root.
            IConfigurationRoot configurationRoot = CreateConfigurationRoot();

            // Create a container.
            var sc = new ServiceCollection();

            // Add the google apis.
            sc.AddGoogleApi(configurationRoot.GetSection("google"));

            // Add the youtube client.
            sc.AddYouTubeClient();

            // Get the provider.
            IServiceProvider sp = sc.BuildServiceProvider();

            // Get the client.
            return sp.GetRequiredService<IYouTubeClient>();
        }

        #endregion

        #region Tests

        [Theory]
        [InlineData("fFoLbsA5Sx0")]
        public async Task Test_GetVideo_Async(string videoId)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(videoId)) throw new ArgumentNullException(nameof(videoId));
            
            // Create the youtube client.
            var youTubeClient = CreateYouTubeClient();

            // Create the request.
            var request = new VideoListRequest(
                new string[1] { videoId },
                new Part[1] { Part.Id },
                null,
                null
            );

            // Make the call.
            await youTubeClient.GetVideosAsync(request, CancellationToken.None).ConfigureAwait(false);
        }

        #endregion
    }
}
