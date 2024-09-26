using System.Linq;

using TermColor.Cli.Widgets.Display;

namespace TermColor.Cli.Arguments;

internal static class ArgumentsProcessor
{
    public static void Process(string[] arguments)
    {
        ProcessCommands(arguments);
        ProcessOptions(null, arguments);
    }

    public static void Process(Command command, string[] arguments)
    {
        ProcessOptions(command, arguments);
    }

    private static void ProcessCommands(string[] arguments)
    {
        if (Program.Commands.Length == 0)
        {
            return;
        }

        if (arguments.Length == 0)
        {
            ErrorMessageWidget.Display("no command provided. Use --help for help instructions.");
            Program.Close(false);
        }

        if (Option.HasOptionFormat(arguments[0]))
        {
            return;
        }

        foreach (Command command in Program.Commands)
        {
            if (arguments[0] != command.Name)
            {
                continue;
            }

            command.Execute(arguments.Skip(1).ToArray());
            Program.Close(true);
        }

        ErrorMessageWidget.Display($"the command \"{arguments[0]}\" does not exist. Use --help for help instructions.");
        Program.Close(false);
    }

    private static void ProcessOptions(Command? command, string[] arguments)
    {
        Option[] options = command?.Options ?? Program.Options;

        if (options.Length == 0 || arguments.Length == 0)
        {
            return;
        }

        foreach (string argument in arguments)
        {
            if (!Option.HasOptionFormat(argument))
            {
                continue;
            }

            foreach (Option option in options)
            {
                if (argument != option.Name)
                {
                    continue;
                }

                option.Execute();
                Program.Close(true);
            }

            ErrorMessageWidget.Display($"the option \"{argument}\" does not exist{(command == null ? string.Empty : $" for the command {command.Name}")}. Use --help for help instructions.");
            Program.Close(false);
        }
    }
}