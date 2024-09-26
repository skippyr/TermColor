using System;
using System.IO;
using System.Linq;

using TermColor.FileSystem;

using TermColor.Cli.Design.TerminalThemePorters;
using TermColor.Cli.Widgets.Display;
using TermColor.Cli.Widgets.Input;

namespace TermColor.Cli.Arguments;

internal sealed class PortCommand : Command
{
    public static PortCommand Instance { get; } = new();

    private static readonly TerminalThemePorter[] Porters =
    [
        AlacrittyPorter.Instance,
        KittyPorter.Instance,
        KonsolePorter.Instance,
        LxTerminalPorter.Instance,
        StPorter.Instance,
        WezTermPorter.Instance,
        WindowsTerminalPorter.Instance,
        Xfce4TerminalPorter.Instance,
        XTermPorter.Instance
    ];

    private PortCommand() : base("port", "<THEME-FILE> <TERMINAL> <OUTPUT-FILE>?", "Ports a terminal theme and writes it to a file or to the terminal.")
    {
        OptionsList.Add(new Option("terminals", "Lists the terminals which can be targeted.", () =>
        {
            Console.WriteLine("You can port to the following terminals:");

            foreach (TerminalThemePorter porter in Porters)
            {
                Console.WriteLine($"    {porter.Name}");
            }
        }));
    }

    protected override void OnExecute(string[] arguments)
    {
        switch (arguments.Length)
        {
            case 0:
                ErrorMessageWidget.Display("no theme file provided. Use --help for help instructions.");
                Program.Close(false);
                break;

            case 1:
                ErrorMessageWidget.Display("no target terminal provided. Use --help for help instructions.");
                Program.Close(false);
                break;
        }

        TerminalThemePorter? porter = Porters.FirstOrDefault(porterItem => porterItem.Name == arguments[1]);

        if (porter == null)
        {
            ErrorMessageWidget.Display($"the target terminal \"{arguments[1]}\" is invalid. Use --terminals for available terminals.");
            Program.Close(false);

            return;
        }

        using JsonThemeFileHandler themeFileHandler = new(arguments[0]);
        TextFileHandler? outputFileHandler = null;

        if (arguments.Length > 2)
        {
            if (File.Exists(arguments[2]))
            {
                if (!BoolInputWidget.Read("The output file already exists. Do you want to overwrite it?", false))
                {
                    return;
                }

                Console.WriteLine();
            }

            outputFileHandler = new TextFileHandler("output", arguments[2], true);
        }

        if (outputFileHandler != null)
        {
            porter.Port(outputFileHandler.StreamWriter, themeFileHandler.ReadTheme());
            outputFileHandler.Dispose();
            Console.WriteLine($"Ported your theme to the {porter.Name} terminal.");
        }
        else
        {
            porter.Port(Console.Out, themeFileHandler.ReadTheme());
        }
    }
}