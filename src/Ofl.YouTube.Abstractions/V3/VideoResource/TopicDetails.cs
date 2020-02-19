using System.Collections.Generic;

namespace Ofl.YouTube.V3.VideoResource
{
    public class TopicDetails
    {
        public IReadOnlyCollection<string>? TopicIds { get; set; }
        public IReadOnlyCollection<string>? RelevantTopicIds { get; set; }
    }
}
