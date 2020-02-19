using System.Threading;
using System.Threading.Tasks;
using Ofl.YouTube.V3.PlaylistItemResource;
using Ofl.YouTube.V3.VideoResource;

namespace Ofl.YouTube.V3
{
    public interface IYouTubeClient
    {
        Task<VideoListResponse> GetVideosAsync(VideoListRequest request, CancellationToken cancellationToken);

        Task<PlaylistItemListResponse> GetPlaylistItemsAsync(PlaylistItemListRequest request, CancellationToken cancellationToken);
    }
}
