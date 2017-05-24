using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofl.YouTube.V3
{
    internal static class PartExtensions
    {
        internal static string GetPartsParameter<T>(this IEnumerable<T> parts)
        {
            // Validate parameters.
            if (parts == null) throw new ArgumentNullException(nameof(parts));

            // Cycle through the parts, get the object name and then lower case it.
            return parts.Select(p => Enum.GetName(typeof(T), p).ToCamelCase()).Join(",");
        }
    }
}
