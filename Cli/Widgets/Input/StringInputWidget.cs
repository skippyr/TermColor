using System;
using System.IO;

using TermColor.Cli.Widgets.Display;

namespace TermColor.Cli.Widgets.Input;

internal static class StringInputWidget
{
    public static string Read(string label, string? defaultValue = null)
    {
        while (true)
        {
            Console.Write($"{label}{(defaultValue == null ? string.Empty : $" (leave blank to use: \"{defaultValue}\")")}: ");

            string input = (_ = Console.ReadLine() ?? throw new IOException()).Trim();

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }

            if (defaultValue != null)
            {
                return defaultValue;
            }

            ErrorMessageWidget.Display("this field can not be empty.");
        }
    }
}