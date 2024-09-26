using System.Text.Json.Serialization;

using TermColor.Cli.Design;

namespace TermColor.FileSystem;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Theme))]
internal partial class JsonThemeSerializerContext : JsonSerializerContext;