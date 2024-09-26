using System;

using TermColor.Cli;
using TermColor.Cli.Arguments;
using TermColor.Cli.Widgets.Display;
using TermColor.Desktop.Network;
using TermColor.Desktop.Vcs;

namespace TermColor;

internal static class Program
{
    public const string Name = "term-color";
    public const string ArgumentsFormat = "<COMMAND> <OPTION>? [ARGUMENTS]?...";
    public const string Description = "Ports terminal themes from a single theme file.";
    public const string Version = "1.0.0";
    public const int CreationYear = 2024;
    public const string License = "BSD-3-Clause License";
    public static readonly Developer Author = new() { Name = "Sherman Rofeman", Email = "skippyr.developer@icloud.com" };
    public const string UpstreamUrl = "https://github.com/skippyr/TermColor";

    public static readonly Command[] Commands =
    [
        NewCommand.Instance,
        InfoCommand.Instance,
        PreviewCommand.Instance,
        PortCommand.Instance
    ];

    public static readonly Option[] Options =
    [
        new("help", "Shows the software help instructions.", () => HelpInstructionsWidget.Display()),
        new("version", "Shows the software version.", SoftwareVersionWidget.Display),
        new("repository", "Browses the software repository.", () => WebBrowser.Browse(UpstreamUrl))
    ];

    public static void Main(string[] arguments)
    {
        if (Console.IsInputRedirected || Console.IsOutputRedirected || Console.IsErrorRedirected)
        {
            ErrorMessageWidget.Display("no console stream must be redirected. Ensure to not perform pipelines.");
            Close(false);
        }

        ExtraConsoleFeatures.EnableFeatures();
        ArgumentsProcessor.Process(arguments);
    }

    public static void Close(bool hadSuccess)
    {
        Environment.Exit(hadSuccess ? 0 : 1);
    }
}
