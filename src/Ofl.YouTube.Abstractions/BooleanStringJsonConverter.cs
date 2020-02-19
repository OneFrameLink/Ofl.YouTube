using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ofl.YouTube
{
    internal class BooleanStringJsonConverter : JsonConverter<bool>
    {
        #region Overrides

        public override bool Read(
            ref Utf8JsonReader reader, 
            Type typeToConvert, 
            JsonSerializerOptions options
        )
        {
            // Validate parameters.
            if (typeToConvert == null) throw new ArgumentNullException(nameof(typeToConvert));
            if (options == null) throw new ArgumentNullException(nameof(options));

            // Get the span to work with.
            var span = reader.HasValueSequence
                ? reader.ValueSequence.FirstSpan
                : reader.ValueSpan;

            // Check for true and false.
            if (
                span.Length > 0 && (span[0] == 't' || span[0] == 'T')
                && span.Length > 1 && (span[1] == 'r' || span[1] == 'R')
                && span.Length > 2 && (span[2] == 'u' || span[2] == 'U')
                && span.Length > 3 && (span[3] == 'e' || span[3] == 'E')
            )
                return true;

            // Check false.
            if (
                span.Length > 0 && (span[0] == 'f' || span[0] == 'F')
                && span.Length > 1 && (span[1] == 'a' || span[1] == 'A')
                && span.Length > 2 && (span[2] == 'l' || span[2] == 'L')
                && span.Length > 3 && (span[3] == 's' || span[3] == 'S')
                && span.Length > 4 && (span[4] == 'e' || span[4] == 'E')
            )
                return false;

            // Couldn't figure out what the value is.
            throw new JsonException("Could not parse some variation of true/false.");
        }

        public override void Write(
            Utf8JsonWriter writer, 
            bool value, 
            JsonSerializerOptions options
        )
        {
            // Validate parameters.
            if (writer == null) throw new ArgumentNullException(nameof(writer));
            if (options == null) throw new ArgumentNullException(nameof(options));

            // Wriet the value as a string.
            writer.WriteStringValue(value.ToString());
        }

        #endregion
    }
}
