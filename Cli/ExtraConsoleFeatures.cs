using System;

using TermColor.Cli.Drivers;

namespace TermColor.Cli;

internal static class ExtraConsoleFeatures
{
    public static void EnableFeatures()
    {
        if (OperatingSystem.IsWindows())
        {
            WindowsDriver.EnableVirtualTerminalProcessing();
        }
    }

    public static void ApplyAnsiColor(int color, ConsoleLayer layer)
    {
        WriteAnsiEscapeSequence($"\x1b[{layer.Value}8;5;{color}m");
    }

    public static void ApplyHexColor(int color, ConsoleLayer layer)
    {
        WriteAnsiEscapeSequence($"\x1b[{layer.Value}8;2;{color >> 16 & 0xff};{color >> 8 & 0xff};{color & 0xff}m");
    }

    public static void ResetColors()
    {
        WriteAnsiEscapeSequence("\x1b[39;49m");
    }

    private static void WriteAnsiEscapeSequence(string sequence)
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Write(sequence);
        }
        else if (!Console.IsErrorRedirected)
        {
            Console.Error.Write(sequence);
        }
    }
}