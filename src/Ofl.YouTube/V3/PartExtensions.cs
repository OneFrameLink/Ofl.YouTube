using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofl.YouTube.V3
{
    internal static class PartExtensions
    {
        public static string GetPartsParameter<T>(this IEnumerable<T> parts)
            => parts.Select(p => Enum.GetName(typeof(T), p).ToCamelCase()).Join(",");
    }
}
