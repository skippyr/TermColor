namespace TermColor.Cli;

internal sealed class ConsoleLayer
{
    public static ConsoleLayer Foreground { get; } = new(3);
    public static ConsoleLayer Background { get; } = new(4);

    public int Value { get; }

    private ConsoleLayer(int value)
    {
        Value = value;
    }
}