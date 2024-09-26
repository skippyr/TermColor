using System;
using System.IO;

using TermColor.Cli.Widgets.Display;

namespace TermColor.Cli.Widgets.Input;

internal static class UrlInputWidget
{
    public static string Read(string label, string? defaultValue = null)
    {
        while (true)
        {
            Console.Write($"{label}{(defaultValue == null ? string.Empty : $" (leave blank to use: \"{defaultValue}\")")}: ");

            string input = (_ = Console.ReadLine() ?? throw new IOException()).Trim();

            if (defaultValue != null && string.IsNullOrEmpty(input))
            {
                return defaultValue;
            }

            if (Uri.IsWellFormedUriString(input, UriKind.Absolute))
            {
                return input;
            }

            ErrorMessageWidget.Display("this field must be an URL in a format like \"https://github.com/user/repo\".");
        }
    }
}