using System;
using System.IO;
using System.Net.Mail;

using TermColor.Cli.Widgets.Display;

namespace TermColor.Cli.Widgets.Input;

internal static class EmailInputWidget
{
    public static string Read(string label, string? defaultValue = null)
    {
        while (true)
        {
            Console.Write($"{label}{(defaultValue == null ? string.Empty : $" (leave blank to use: \"{defaultValue}\")")}: ");

            string input = (_ = Console.ReadLine() ?? throw new IOException()).ToLower().Trim();

            if (defaultValue != null && string.IsNullOrEmpty(input))
            {
                return defaultValue;
            }

            try
            {
                _ = new MailAddress(input);

                return input;
            }
            catch (Exception exception) when (exception is FormatException or ArgumentException)
            {
            }

            ErrorMessageWidget.Display("this field must be an e-mail in a format like \"john.doe@email.com\".");
        }
    }
}