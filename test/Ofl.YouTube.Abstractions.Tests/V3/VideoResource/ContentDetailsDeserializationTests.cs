using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Ofl.YouTube.Abstractions.Tests.V3.VideoResource.Resources;
using Ofl.YouTube.V3.VideoResource;
using Xunit;

namespace Ofl.YouTube.Abstractions.Tests.V3.VideoResource
{
    public class ContentDetailsDeserializationTests
    {
        [Fact]
        public async Task Test_ContentDetails_Deserialization_Async()
        {
            // Get the stream.
            using Stream? stream = typeof(ContentDetailsDeserializationTests).GetTypeInfo().Assembly
                .GetManifestResourceStream(typeof(Marker), "ContentDetails.json");

            // Deserialize.
            VideoListResponse response = await JsonSerializer
                .DeserializeAsync<VideoListResponse>(stream, new JsonSerializerOptions {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                })
                .ConfigureAwait(false);

            // Validate.
            Assert.Equal(
                TimeSpan.FromMinutes(18).Add(TimeSpan.FromSeconds(8)), 
                response.Items.First().ContentDetails?.Duration
            );
        }
    }
}
