using System;
using System.Linq;

using TermColor.Cli.Arguments;

namespace TermColor.Cli.Widgets.Display;

internal static class HelpInstructionsWidget
{
    public static void Display(Command? command = null)
    {
        Console.WriteLine($"Usage: {Program.Name}{(command == null ? string.Empty : $" {command.Name}")} {command?.ArgumentsFormat ?? Program.ArgumentsFormat}");
        Console.WriteLine(command?.Description ?? Program.Description);

        Option[] options = command?.Options ?? Program.Options;
        int padding;

        if (options.Length > 0)
        {
            Console.WriteLine();
            Console.WriteLine("AVAILABLE OPTIONS");

            padding = options.Max(option => option.Name.Length);

            foreach (Option option in options)
            {
                Console.WriteLine($"    {option.Name.PadRight(padding)}     {option.Description}");
            }
        }

        if (command != null || Program.Commands.Length == 0)
        {
            return;
        }

        Console.WriteLine();
        Console.WriteLine("AVAILABLE COMMANDS");

        padding = Program.Commands.Max(commandItem => commandItem.Name.Length);

        foreach (Command commandItem in Program.Commands)
        {
            Console.WriteLine($"    {commandItem.Name.PadRight(padding)}     {commandItem.Description}");
        }

        Console.WriteLine();
        Console.WriteLine("Use --help with each command for their help instructions.");
    }
}