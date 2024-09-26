using System;
using System.IO;

using TermColor.Cli.Widgets.Display;
using TermColor.Converters;

namespace TermColor.Cli.Widgets.Input;

internal static class HexColorInputWidget
{
    public static int Read(string label, int? defaultValue = null)
    {
        while (true)
        {
            Console.Write($"{label}{(defaultValue == null ? string.Empty : $" (leave blank to use \"#{defaultValue:X6}\")")}: ");

            string input = (_ = Console.ReadLine() ?? throw new IOException()).Trim();

            if (defaultValue != null && string.IsNullOrEmpty(input))
            {
                return defaultValue.Value;
            }

            try
            {
                return HexStringConverter.Convert(input);
            }
            catch (FormatException)
            {
            }

            ErrorMessageWidget.Display("this field must be a hex color in a format like \"#RRGGBB\".");
        }
    }
}