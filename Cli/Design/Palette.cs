using System.Text.Json.Serialization;

namespace TermColor.Cli.Design;

internal sealed record Palette
{
    [JsonPropertyName("dark")]
    public required ColorGroup DarkColors { get; init; }
    
    [JsonPropertyName("light")]
    public required ColorGroup LightColors { get; init; }
}