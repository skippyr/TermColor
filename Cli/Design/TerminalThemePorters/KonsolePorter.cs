using System.IO;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal sealed class KonsolePorter : TerminalThemePorter
{
    public static KonsolePorter Instance { get; } = new();

    private KonsolePorter() : base("konsole")
    {
    }

    public override void Port(TextWriter writer, Theme theme)
    {
        writer.WriteLine($"[General]");
        writer.WriteLine($"Description={theme.Name}");
        WriteColorProperty(writer, "Background", theme.Palette.DarkColors.Black, theme.Palette.LightColors.Black);
        WriteColorProperty(writer, "Foreground", theme.Palette.DarkColors.White, theme.Palette.LightColors.White);
        WriteColorProperty(writer, "Color0", theme.Palette.DarkColors.Black, theme.Palette.LightColors.Black);
        WriteColorProperty(writer, "Color1", theme.Palette.DarkColors.Red, theme.Palette.LightColors.Red);
        WriteColorProperty(writer, "Color2", theme.Palette.DarkColors.Green, theme.Palette.LightColors.Green);
        WriteColorProperty(writer, "Color3", theme.Palette.DarkColors.Yellow, theme.Palette.LightColors.Yellow);
        WriteColorProperty(writer, "Color4", theme.Palette.DarkColors.Blue, theme.Palette.LightColors.Blue);
        WriteColorProperty(writer, "Color5", theme.Palette.DarkColors.Magenta, theme.Palette.LightColors.Magenta);
        WriteColorProperty(writer, "Color6", theme.Palette.DarkColors.Cyan, theme.Palette.LightColors.Cyan);
        WriteColorProperty(writer, "Color7", theme.Palette.DarkColors.White, theme.Palette.LightColors.White);
    }

    private static void WriteColorProperty(TextWriter writer, string property, int colorDefault, int colorIntense)
    {
        writer.WriteLine($"[{property}]");
        writer.WriteLine($"Color=#{colorDefault:x6}");
        writer.WriteLine($"[{property}Faint]");
        writer.WriteLine($"Color=#{colorDefault:x6}");
        writer.WriteLine($"[{property}Intense]");
        writer.WriteLine($"Color=#{colorIntense:x6}");
    }
}