using System;

using TermColor.Cli.Design;

namespace TermColor.Cli.Widgets.Display;

internal static class ThemeInfoWidget
{
    public static void Display(Theme theme, bool showPalette, bool shouldIndent)
    {
        string indentation = shouldIndent ? "    " : string.Empty;

        Console.WriteLine($"{indentation}Name: {theme.Name}");
        Console.WriteLine($"{indentation}Author: {theme.Author}");
        Console.WriteLine($"{indentation}License: {theme.License}");
        Console.WriteLine($"{indentation}Upstream Url: <{theme.UpstreamUrl}>");

        if (!showPalette)
        {
            return;
        }

        Console.WriteLine($"{indentation}Palette:");
        Console.WriteLine($"{indentation}    Dark Colors:");
        WriteColor(indentation, theme.Palette.DarkColors.Black, "Black");
        WriteColor(indentation, theme.Palette.DarkColors.Red, "Red");
        WriteColor(indentation, theme.Palette.DarkColors.Green, "Green");
        WriteColor(indentation, theme.Palette.DarkColors.Yellow, "Yellow");
        WriteColor(indentation, theme.Palette.DarkColors.Blue, "Blue");
        WriteColor(indentation, theme.Palette.DarkColors.Magenta, "Magenta");
        WriteColor(indentation, theme.Palette.DarkColors.Cyan, "Cyan");
        WriteColor(indentation, theme.Palette.DarkColors.White, "White");
        Console.WriteLine($"{indentation}    Light Colors:");
        WriteColor(indentation, theme.Palette.LightColors.Black, "Black");
        WriteColor(indentation, theme.Palette.LightColors.Red, "Red");
        WriteColor(indentation, theme.Palette.LightColors.Green, "Green");
        WriteColor(indentation, theme.Palette.LightColors.Yellow, "Yellow");
        WriteColor(indentation, theme.Palette.LightColors.Blue, "Blue");
        WriteColor(indentation, theme.Palette.LightColors.Magenta, "Magenta");
        WriteColor(indentation, theme.Palette.LightColors.Cyan, "Cyan");
        WriteColor(indentation, theme.Palette.LightColors.White, "White");
    }


    private static void WriteColor(string indentation, int color, string name)
    {
        Console.Write($"{indentation}        {name + ":",-8} #{color:x6}  ");
        ExtraConsoleFeatures.ApplyHexColor(color, ConsoleLayer.Background);
        Console.Write("   ");
        ExtraConsoleFeatures.ResetColors();
        Console.WriteLine();
    }
}