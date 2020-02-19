using System;

namespace Ofl.YouTube
{
    public class ParsedUrl
    {
        #region Constructors/factories

        public static ParsedUrl FromVideoId(string videoId) =>
            FromVideoId(videoId, false);

        public static ParsedUrl FromVideoId(string videoId, bool isShortUrl)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(videoId)) throw new ArgumentNullException(nameof(videoId));

            // Create and return.
            return new ParsedUrl(videoId, null, isShortUrl);
        }

        public static ParsedUrl FromPlaylistId(string playlistId) =>
            FromPlaylistId(playlistId, false);

        public static ParsedUrl FromPlaylistId(string playlistId, bool isShortUrl)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(playlistId)) throw new ArgumentNullException(nameof(playlistId));

            // Create and return.
            return new ParsedUrl(null, playlistId, isShortUrl);
        }

        private ParsedUrl(
            string? videoId,
            string? playlistId,
            bool isShortUrl
        )
        {
            // Validate parameters.  One or the other must be null.
            if (string.IsNullOrWhiteSpace(videoId))
            {
                // The playlist ID cannot be null.
                if (string.IsNullOrWhiteSpace(playlistId))
                    throw new ArgumentNullException(nameof(playlistId), 
                        $"The {nameof(playlistId)} parameter cannot be null or whitespace when the {nameof(videoId)} parameter is null or whitespace."
                    );
            } else if (!string.IsNullOrWhiteSpace(playlistId))
                // Throw, cannot both be null.
                throw new ArgumentException(
                    $"The {nameof(playlistId)} parameter cannot be non-null and non-whitespace when the {nameof(videoId)} parameter is non-null and non-whitespace.",
                    nameof(playlistId)
                );

            // Assign values.
            VideoId = videoId;
            PlaylistId = playlistId;
            IsShortUrl = isShortUrl;
        }

        #endregion

        #region Instance, readonly state

        public string? VideoId { get; }

        public string? PlaylistId { get;  }

        public bool IsShortUrl { get; }

        #endregion
    }
}
