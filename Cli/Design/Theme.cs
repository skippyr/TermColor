using System.Text.Json.Serialization;

using TermColor.Desktop.Vcs;

namespace TermColor.Cli.Design;

internal sealed record Theme
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    [JsonPropertyName("author")]
    public required Developer Author { get; init; }

    [JsonPropertyName("license")]
    public required string License { get; init; }

    [JsonPropertyName("upstreamUrl")]
    public required string UpstreamUrl { get; init; }

    [JsonPropertyName("palette")]
    [JsonRequired]
    public Palette Palette { get; set; } = new()
    {
        DarkColors = new ColorGroup
        {
            Black = 0x000000,
            Red = 0xff0000,
            Green = 0x00ff00,
            Yellow = 0xffff00,
            Blue = 0x0000ff,
            Magenta = 0xff00ff,
            Cyan = 0x00ffff,
            White = 0xffffff
        },
        LightColors = new ColorGroup
        {
            Black = 0x999999,
            Red = 0xff0000,
            Green = 0x00ff00,
            Yellow = 0xffff00,
            Blue = 0x0000ff,
            Magenta = 0xff00ff,
            Cyan = 0x00ffff,
            White = 0xffffff
        }
    };
}