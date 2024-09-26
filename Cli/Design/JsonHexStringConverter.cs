using System;
using System.Text.Json;
using System.Text.Json.Serialization;

using TermColor.Converters;

namespace TermColor.Cli.Design;

internal sealed class JsonHexStringConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return HexStringConverter.Convert(reader.GetString() ?? throw new InvalidOperationException());
        }
        catch (Exception exception) when (exception is InvalidOperationException or FormatException)
        {
            throw new JsonException();
        }
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"#{value:x6}");
    }
}