using System.IO;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal sealed class LxTerminalPorter : TerminalThemePorter
{
    public static LxTerminalPorter Instance { get; } = new();

    private LxTerminalPorter() : base("lxterminal")
    {
    }

    public override void Port(TextWriter writer, Theme theme)
    {
        writer.WriteLine("[general]");
        writer.WriteLine("color_preset=Custom");
        WriteColorProperty(writer, "bgcolor", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "fgcolor", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "palette_color_0", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "palette_color_1", theme.Palette.DarkColors.Red);
        WriteColorProperty(writer, "palette_color_2", theme.Palette.DarkColors.Green);
        WriteColorProperty(writer, "palette_color_3", theme.Palette.DarkColors.Yellow);
        WriteColorProperty(writer, "palette_color_4", theme.Palette.DarkColors.Blue);
        WriteColorProperty(writer, "palette_color_5", theme.Palette.DarkColors.Magenta);
        WriteColorProperty(writer, "palette_color_6", theme.Palette.DarkColors.Cyan);
        WriteColorProperty(writer, "palette_color_6", theme.Palette.DarkColors.Cyan);
        WriteColorProperty(writer, "palette_color_7", theme.Palette.DarkColors.White);
        WriteColorProperty(writer, "palette_color_8", theme.Palette.LightColors.Black);
        WriteColorProperty(writer, "palette_color_9", theme.Palette.LightColors.Red);
        WriteColorProperty(writer, "palette_color_10", theme.Palette.LightColors.Green);
        WriteColorProperty(writer, "palette_color_11", theme.Palette.LightColors.Yellow);
        WriteColorProperty(writer, "palette_color_12", theme.Palette.LightColors.Blue);
        WriteColorProperty(writer, "palette_color_13", theme.Palette.LightColors.Magenta);
        WriteColorProperty(writer, "palette_color_14", theme.Palette.LightColors.Cyan);
        WriteColorProperty(writer, "palette_color_15", theme.Palette.LightColors.White);
    }

    private static void WriteColorProperty(TextWriter writer, string property, int color)
    {
        writer.WriteLine($"{property}=#{color:x6}");
    }
}