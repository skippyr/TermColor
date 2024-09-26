using System.Collections.Generic;

using TermColor.Cli.Widgets.Display;

namespace TermColor.Cli.Arguments;

internal abstract class Command
{
    public string Name { get; }
    public string ArgumentsFormat { get; }
    public string Description { get; }
    protected List<Option> OptionsList { get; }
    public Option[] Options => [.. OptionsList];

    protected abstract void OnExecute(string[] arguments);

    protected Command(string name, string argumentsFormat, string description)
    {
        Name = name;
        ArgumentsFormat = argumentsFormat;
        Description = description;

        OptionsList =
        [
            new Option("help", "Shows the command help instructions.", () => HelpInstructionsWidget.Display(this))
        ];
    }

    public void Execute(string[] arguments)
    {
        ArgumentsProcessor.Process(this, arguments);
        OnExecute(arguments);
    }
}