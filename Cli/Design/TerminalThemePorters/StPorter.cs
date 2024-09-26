using System.IO;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal sealed class StPorter : TerminalThemePorter
{
    public static StPorter Instance { get; } = new();

    private StPorter() : base("st")
    {
    }

    public override void Port(TextWriter writer, Theme theme)
    {
        writer.WriteLine($"static const char *colorname[] = {{{FormatColor(theme.Palette.DarkColors.Black)}, {FormatColor(theme.Palette.DarkColors.Red)}, {FormatColor(theme.Palette.DarkColors.Green)}, {FormatColor(theme.Palette.DarkColors.Yellow)},");
        writer.WriteLine($"\t\t\t\t  {FormatColor(theme.Palette.DarkColors.Blue)}, {FormatColor(theme.Palette.DarkColors.Magenta)}, {FormatColor(theme.Palette.DarkColors.Cyan)}, {FormatColor(theme.Palette.DarkColors.White)},");
        writer.WriteLine($"\t\t\t\t  {FormatColor(theme.Palette.LightColors.Black)}, {FormatColor(theme.Palette.LightColors.Red)}, {FormatColor(theme.Palette.LightColors.Green)}, {FormatColor(theme.Palette.LightColors.Yellow)},");
        writer.WriteLine($"\t\t\t\t  {FormatColor(theme.Palette.LightColors.Blue)}, {FormatColor(theme.Palette.LightColors.Magenta)}, {FormatColor(theme.Palette.LightColors.Cyan)}, {FormatColor(theme.Palette.LightColors.White)}}};");
        writer.WriteLine("unsigned int defaultbg = 0;");
        writer.WriteLine("unsigned int defaultfg = 15;");
        writer.WriteLine("unsigned int defaultcs = 15;");
        writer.WriteLine("unsigned int defaultrcs = 0;");
    }

    private static string FormatColor(int color)
    {
        return $"\"#{color:x6}\"";
    }
}