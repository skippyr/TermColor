using System.IO;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal sealed class WindowsTerminalPorter : TerminalThemePorter
{
    public static WindowsTerminalPorter Instance { get; } = new();

    private WindowsTerminalPorter() : base("windows-terminal")
    {
    }

    public override void Port(TextWriter writer, Theme theme)
    {
        writer.WriteLine("{");
        writer.WriteLine($"    \"name\": \"{theme.Name}\",");
        WriteColorProperty(writer, "background", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "foreground", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "cursorColor", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "selectionBackground", theme.Palette.LightColors.White);
        WriteColorProperty(writer, "black", theme.Palette.DarkColors.Black);
        WriteColorProperty(writer, "red", theme.Palette.DarkColors.Red);
        WriteColorProperty(writer, "green", theme.Palette.DarkColors.Green);
        WriteColorProperty(writer, "yellow", theme.Palette.DarkColors.Yellow);
        WriteColorProperty(writer, "blue", theme.Palette.DarkColors.Blue);
        WriteColorProperty(writer, "purple", theme.Palette.DarkColors.Magenta);
        WriteColorProperty(writer, "cyan", theme.Palette.DarkColors.Cyan);
        WriteColorProperty(writer, "white", theme.Palette.DarkColors.White);
        WriteColorProperty(writer, "brightBlack", theme.Palette.LightColors.Black);
        WriteColorProperty(writer, "brightRed", theme.Palette.LightColors.Red);
        WriteColorProperty(writer, "brightGreen", theme.Palette.LightColors.Green);
        WriteColorProperty(writer, "brightYellow", theme.Palette.LightColors.Yellow);
        WriteColorProperty(writer, "brightBlue", theme.Palette.LightColors.Blue);
        WriteColorProperty(writer, "brightPurple", theme.Palette.LightColors.Magenta);
        WriteColorProperty(writer, "brightCyan", theme.Palette.LightColors.Cyan);
        WriteColorProperty(writer, "brightWhite", theme.Palette.LightColors.White, false);
        writer.WriteLine("}");
    }

    private static void WriteColorProperty(TextWriter writer, string property, int color, bool includeTrailingComma = true)
    {
        writer.WriteLine($"    \"{property}\": \"#{color:x6}\"{(includeTrailingComma ? "," : string.Empty)}");
    }
}