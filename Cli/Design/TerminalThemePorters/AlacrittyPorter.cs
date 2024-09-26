using System.IO;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal sealed class AlacrittyPorter : TerminalThemePorter
{
    public static AlacrittyPorter Instance { get; } = new();

    private AlacrittyPorter() : base("alacritty")
    {
    }

    public override void Port(TextWriter writer, Theme theme)
    {
        WriteSection(writer, "primary");
        WriteColorProperty(writer, "background", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "foreground", theme.Palette.LightColors.White);
        WriteSection(writer, "colors.cursor");
        WriteColorProperty(writer, "cursor", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "text", theme.Palette.DarkColors.Black);
        WriteSection(writer, "colors.selection");
        WriteColorProperty(writer, "background", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "text", theme.Palette.DarkColors.Black);
        WriteSection(writer, "colors.normal");
        WriteColorProperty(writer, "black", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "red", theme.Palette.DarkColors.Red);
        WriteColorProperty(writer, "green", theme.Palette.DarkColors.Green);
        WriteColorProperty(writer, "yellow", theme.Palette.DarkColors.Yellow);
        WriteColorProperty(writer, "blue", theme.Palette.DarkColors.Blue);
        WriteColorProperty(writer, "magenta", theme.Palette.DarkColors.Magenta);
        WriteColorProperty(writer, "cyan", theme.Palette.DarkColors.Cyan);
        WriteColorProperty(writer, "white", theme.Palette.DarkColors.White);
        WriteSection(writer, "colors.bright");
        WriteColorProperty(writer, "black", theme.Palette.LightColors.Black);
        WriteColorProperty(writer, "red", theme.Palette.LightColors.Red);
        WriteColorProperty(writer, "green", theme.Palette.LightColors.Green);
        WriteColorProperty(writer, "yellow", theme.Palette.LightColors.Yellow);
        WriteColorProperty(writer, "blue", theme.Palette.LightColors.Blue);
        WriteColorProperty(writer, "magenta", theme.Palette.LightColors.Magenta);
        WriteColorProperty(writer, "cyan", theme.Palette.LightColors.Cyan);
        WriteColorProperty(writer, "white", theme.Palette.LightColors.White);
    }

    private static void WriteSection(TextWriter writer, string section)
    {
        writer.WriteLine($"[{section}]");
    }

    private static void WriteColorProperty(TextWriter writer, string property, int color)
    {
        writer.WriteLine($"{property} = \"#{color:x6}\"");
    }
}