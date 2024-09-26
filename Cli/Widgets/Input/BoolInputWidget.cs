using System;
using System.IO;

using TermColor.Cli.Widgets.Display;

namespace TermColor.Cli.Widgets.Input;

internal static class BoolInputWidget
{
    public static bool Read(string label, bool? defaultValue = null)
    {
        while (true)
        {
            Console.Write($"{label} (y/n){(defaultValue == null ? string.Empty : $" (leave blank to use: '{(defaultValue.Value ? 'y' : 'n')}')")}: ");

            string input = (_ = Console.ReadLine() ?? throw new IOException()).Trim();

            if (defaultValue != null && string.IsNullOrEmpty(input))
            {
                return defaultValue.Value;
            }

            if (input is "y" or "n")
            {
                return input == "y";
            }

            ErrorMessageWidget.Display("this field can only be 'y' (meaning \"yes\") or 'n' (meaning \"no\").");
        }
    }
}