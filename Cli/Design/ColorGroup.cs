using System.Text.Json.Serialization;

namespace TermColor.Cli.Design;

internal sealed record ColorGroup
{
    [JsonPropertyName("black")]
    [JsonConverter(typeof(JsonHexStringConverter))]
    public required int Black { get; set; }

    [JsonPropertyName("red")]
    [JsonConverter(typeof(JsonHexStringConverter))]
    public required int Red { get; set; }

    [JsonPropertyName("green")]
    [JsonConverter(typeof(JsonHexStringConverter))]
    public required int Green { get; set; }

    [JsonPropertyName("yellow")]
    [JsonConverter(typeof(JsonHexStringConverter))]
    public required int Yellow { get; set; }

    [JsonPropertyName("blue")]
    [JsonConverter(typeof(JsonHexStringConverter))]
    public required int Blue { get; set; }

    [JsonPropertyName("magenta")]
    [JsonConverter(typeof(JsonHexStringConverter))]
    public required int Magenta { get; set; }

    [JsonPropertyName("cyan")]
    [JsonConverter(typeof(JsonHexStringConverter))]
    public required int Cyan { get; set; }

    [JsonPropertyName("white")]
    [JsonConverter(typeof(JsonHexStringConverter))]
    public required int White { get; set; }
}