using System.IO;

namespace TermColor.Cli.Design.TerminalThemePorters;

internal abstract class TerminalThemePorter(string name)
{
    public string Name { get; } = name;

    public abstract void Port(TextWriter writer, Theme theme);
}