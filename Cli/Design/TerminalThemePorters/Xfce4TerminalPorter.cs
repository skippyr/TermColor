using System.IO;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal sealed class Xfce4TerminalPorter : TerminalThemePorter
{
    public static Xfce4TerminalPorter Instance { get; } = new();

    private Xfce4TerminalPorter() : base("xfce4-terminal")
    {
    }

    public override void Port(TextWriter writer, Theme theme)
    {
        writer.WriteLine("[Scheme]");
        writer.WriteLine($"Name={theme.Name}");
        writer.WriteLine($"ColorBackground={FormatColor(theme.Palette.DarkColors.Black)}");
        writer.WriteLine($"ColorCursor={FormatColor(theme.Palette.LightColors.White)}");
        writer.WriteLine($"ColorForeground={FormatColor(theme.Palette.LightColors.White)}");
        writer.WriteLine($"ColorPalette={FormatColor(theme.Palette.DarkColors.Black)};{FormatColor(theme.Palette.DarkColors.Red)};{FormatColor(theme.Palette.DarkColors.Green)};{FormatColor(theme.Palette.DarkColors.Yellow)};{FormatColor(theme.Palette.DarkColors.Blue)};{FormatColor(theme.Palette.DarkColors.Magenta)};{FormatColor(theme.Palette.DarkColors.Cyan)};{FormatColor(theme.Palette.DarkColors.White)};{FormatColor(theme.Palette.LightColors.Black)};{FormatColor(theme.Palette.LightColors.Red)};{FormatColor(theme.Palette.LightColors.Green)};{FormatColor(theme.Palette.LightColors.Yellow)};{FormatColor(theme.Palette.LightColors.Blue)};{FormatColor(theme.Palette.LightColors.Magenta)};{FormatColor(theme.Palette.LightColors.Cyan)};{FormatColor(theme.Palette.LightColors.White)}");
    }

    private static string FormatColor(int color)
    {
        return $"#{color:x6}";
    }
}