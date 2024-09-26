using System;

using TermColor.Cli.Design;
using TermColor.FileSystem;

namespace TermColor.Cli.Arguments;

internal sealed class PreviewCommand : Command
{
    public static PreviewCommand Instance { get; } = new();

    private PreviewCommand() : base("preview", "<THEME-FILE>?", "Previews the colors of a theme file or of the current terminal theme.")
    {
    }

    protected override void OnExecute(string[] arguments)
    {
        if (arguments.Length == 0)
        {
            PreviewTerminalThemeColors();
            return;
        }

        PreviewThemeFileColors(arguments[0]);
    }

    private static void PreviewThemeFileColors(string path)
    {
        using JsonThemeFileHandler themeFileHandler = new(path);
        Theme theme = themeFileHandler.ReadTheme();

        WriteHeader(true);
        WriteColor(0, theme.Palette.DarkColors.Black);
        WriteColor(1, theme.Palette.DarkColors.Red);
        WriteColor(2, theme.Palette.DarkColors.Green);
        WriteColor(3, theme.Palette.DarkColors.Yellow);
        WriteColor(4, theme.Palette.DarkColors.Blue);
        WriteColor(5, theme.Palette.DarkColors.Magenta);
        WriteColor(6, theme.Palette.DarkColors.Cyan);
        WriteColor(7, theme.Palette.DarkColors.White);
        WriteColor(8, theme.Palette.LightColors.Black);
        WriteColor(9, theme.Palette.LightColors.Red);
        WriteColor(10, theme.Palette.LightColors.Green);
        WriteColor(11, theme.Palette.LightColors.Yellow);
        WriteColor(12, theme.Palette.LightColors.Blue);
        WriteColor(13, theme.Palette.LightColors.Magenta);
        WriteColor(14, theme.Palette.LightColors.Cyan);
        WriteColor(15, theme.Palette.LightColors.White);
    }

    private static void PreviewTerminalThemeColors()
    {
        WriteHeader(false);

        for (int offset = 0; offset < 16; ++offset)
        {
            WriteColor(offset);
        }
    }

    private static void WriteHeader(bool includesHexColors)
    {
        Console.WriteLine($"ANSI  {"Name",-13}{(includesHexColors ? $"  {"Hex",-7}" : string.Empty)}  Preview");
    }

    private static void WriteColor(int offset, int? hexColor = null)
    {
        string[] names =
        [
            "Dark Black", "Dark Red", "Dark Green", "Dark Yellow", "Dark Blue", "Dark Magenta", "Dark Cyan", "Dark White",
            "Light Black", "Light Red", "Light Green", "Light Yellow", "Light Blue", "Light Magenta", "Light Cyan", "Light White"
        ];

        Console.Write($"{offset,4}  {names[offset],-13}  ");

        if (hexColor != null)
        {
            Console.Write($"#{hexColor:x6}  ");
            ExtraConsoleFeatures.ApplyHexColor(hexColor.Value, ConsoleLayer.Background);
        }
        else
        {
            ExtraConsoleFeatures.ApplyAnsiColor(offset, ConsoleLayer.Background);
        }

        Console.Write("   ");
        ExtraConsoleFeatures.ResetColors();
        Console.Write("  ");

        if (hexColor != null)
        {
            ExtraConsoleFeatures.ApplyHexColor(hexColor.Value, ConsoleLayer.Foreground);
        }
        else
        {
            ExtraConsoleFeatures.ApplyAnsiColor(offset, ConsoleLayer.Foreground);
        }

        Console.Write("Here Be Dragons!");
        ExtraConsoleFeatures.ResetColors();
        Console.WriteLine();
    }
}