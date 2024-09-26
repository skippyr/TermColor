using System;

using TermColor.Platform;

namespace TermColor.Cli.Widgets.Display;

internal static class SoftwareVersionWidget
{
    public static void Display()
    {
        int currentYear = DateTime.Now.Year;

        Console.WriteLine($"{Program.Name} {Program.Version} (running on {ExtraOperatingSystemInfo.Name} with .NET {Environment.Version}).");
        Console.WriteLine($"{Program.License}. Copyright © {Program.CreationYear}{(currentYear == Program.CreationYear ? string.Empty : $"-{currentYear}")} {Program.Author}.");
        Console.WriteLine();
        Console.WriteLine($"Software repository available at <{Program.UpstreamUrl}>.");
    }
}