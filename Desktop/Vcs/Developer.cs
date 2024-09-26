using System.Text.Json.Serialization;

namespace TermColor.Desktop.Vcs;

internal sealed record Developer
{
    [JsonPropertyName("name")]
    [JsonRequired]
    public string? Name { get; init; }

    [JsonPropertyName("email")]
    [JsonRequired]
    public string? Email { get; init; }

    public override string ToString()
    {
        return $"{Name}{(Email == null ? null : $" <{Email}>")}";
    }
}