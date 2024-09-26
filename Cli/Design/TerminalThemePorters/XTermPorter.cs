using System.IO;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal sealed class XTermPorter : TerminalThemePorter
{
    public static XTermPorter Instance { get; } = new();

    private XTermPorter() : base("xterm")
    {
    }

    public override void Port(TextWriter writer, Theme theme)
    {
        WriteColorProperty(writer, "background", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "foreground", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "color0", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "color1", theme.Palette.DarkColors.Red);
        WriteColorProperty(writer, "color2", theme.Palette.DarkColors.Green);
        WriteColorProperty(writer, "color3", theme.Palette.DarkColors.Yellow);
        WriteColorProperty(writer, "color4", theme.Palette.DarkColors.Blue);
        WriteColorProperty(writer, "color5", theme.Palette.DarkColors.Magenta);
        WriteColorProperty(writer, "color6", theme.Palette.DarkColors.Cyan);
        WriteColorProperty(writer, "color7", theme.Palette.DarkColors.White);
        WriteColorProperty(writer, "color8", theme.Palette.LightColors.Black);
        WriteColorProperty(writer, "color9", theme.Palette.LightColors.Red);
        WriteColorProperty(writer, "color10", theme.Palette.LightColors.Green);
        WriteColorProperty(writer, "color11", theme.Palette.LightColors.Yellow);
        WriteColorProperty(writer, "color12", theme.Palette.LightColors.Blue);
        WriteColorProperty(writer, "color13", theme.Palette.LightColors.Magenta);
        WriteColorProperty(writer, "color14", theme.Palette.LightColors.Cyan);
        WriteColorProperty(writer, "color15", theme.Palette.LightColors.White);
    }

    private static void WriteColorProperty(TextWriter writer, string property, int color)
    {
        writer.WriteLine($"*.{property}: #{color:x6}");
    }
}