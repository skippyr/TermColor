using System;

namespace TermColor.Cli.Widgets.Display;

internal static class ErrorMessageWidget
{
    public static void Display(string message)
    {
        Console.Error.WriteLine($"{Program.Name}: {message}");
    }
}