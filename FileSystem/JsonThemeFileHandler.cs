using System.Text.Json;

using TermColor.Cli.Design;
using TermColor.Cli.Widgets.Display;

namespace TermColor.FileSystem;

internal sealed class JsonThemeFileHandler(string path, bool forceCreation = false) : TextFileHandler("theme", path, forceCreation)
{
    public void WriteTheme(Theme theme)
    {
        Write(JsonSerializer.Serialize(theme, JsonThemeSerializerContext.Default.Theme));
    }

    public Theme ReadTheme()
    {
        try
        {
            return JsonSerializer.Deserialize<Theme>(Read(), JsonThemeSerializerContext.Default.Theme) ?? throw new JsonException();
        }
        catch (JsonException exception)
        {
            ErrorMessageWidget.Display(
                exception.Message.Contains("missing required properties")
                    ? $"the theme file \"{Path}\" is missing the property \"{(exception.Path is { Length: > 2 } ? $"{exception.Path[2..]}." : string.Empty)}{exception.Message.Split(' ')[^1]}\"."
                    : exception.Message.Contains("value could not be converted to") && exception.Path is { Length: > 2 }
                        ? $"the theme file \"{Path}\" has the property \"{exception.Path?[2..]}\" is of a wrong type."
                        : $"the theme file \"{Path}\" contains a bad JSON format.");
            Program.Close(false);

            throw;
        }
    }
}