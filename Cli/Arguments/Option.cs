using System;

namespace TermColor.Cli.Arguments;

internal sealed class Option(string name, string description, Action execute)
{
    public string Name { get; } = $"--{name}";
    public string Description { get; } = description;
    public Action Execute { get; } = execute;

    public static bool HasOptionFormat(string argument)
    {
        return argument.StartsWith("--");
    }
}