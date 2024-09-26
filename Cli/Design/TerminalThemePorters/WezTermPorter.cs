using System.IO;
using System.Linq;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal sealed class WezTermPorter : TerminalThemePorter
{
    public static WezTermPorter Instance { get; } = new();

    private WezTermPorter() : base("wezterm")
    {
    }

    public override void Port(TextWriter writer, Theme theme)
    {
        WriteSection(writer, "metadata");
        WriteStringProperty(writer, "author", theme.Author.ToString());
        WriteStringProperty(writer, "name", theme.Name);
        WriteStringProperty(writer, "origin_url", theme.UpstreamUrl);
        WriteSection(writer, "colors");
        WriteColorProperty(writer, "background", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "foreground", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "cursor_bg", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "cursor_fg", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "cursor_border", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "selection_bg", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "selection_fg", theme.Palette.DarkColors.Black);
        WriteColorGroupProperty(writer, "ansi", theme.Palette.DarkColors);
        WriteColorGroupProperty(writer, "brights", theme.Palette.LightColors);
    }

    private static void WriteSection(TextWriter writer, string section)
    {
        writer.WriteLine($"[{section}]");
    }

    private static void WriteStringProperty(TextWriter writer, string property, string @string)
    {
        writer.WriteLine($"{property} = \"{@string}\"");
    }

    private static void WriteColorProperty(TextWriter writer, string property, int color)
    {
        writer.WriteLine($"{property} = {FormatColor(color)}");
    }

    private static void WriteColorGroupProperty(TextWriter writer, string property, ColorGroup colorGroup)
    {
        writer.WriteLine($"{property} = [{FormatColor(colorGroup.Black)}, {FormatColor(colorGroup.Red)}, {FormatColor(colorGroup.Green)}, {FormatColor(colorGroup.Yellow)}, {FormatColor(colorGroup.Blue)}, {FormatColor(colorGroup.Magenta)},");
        writer.WriteLine($"{string.Concat(Enumerable.Repeat(' ', property.Length))}    {FormatColor(colorGroup.Cyan)}, {FormatColor(colorGroup.White)}]");
    }

    private static string FormatColor(int color)
    {
        return $"\"#{color:x6}\"";
    }
}