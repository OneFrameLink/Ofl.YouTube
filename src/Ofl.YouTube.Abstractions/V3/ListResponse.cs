using System.Collections.Generic;

namespace Ofl.YouTube.V3
{
    public abstract class ListResponse<T>
    {
        public string? Kind { get; set; }

        public string? Etag { get; set; }

        public string? NextPageToken { get; set; }

        public string? PrevPageToken { get; set; }

        public PageInfo? PageInfo { get; set; }

        public IReadOnlyCollection<T>? Items { get; set; }
    }
}
