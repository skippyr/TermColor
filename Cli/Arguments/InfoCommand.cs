using TermColor.Cli.Widgets.Display;
using TermColor.FileSystem;

namespace TermColor.Cli.Arguments;

internal sealed class InfoCommand : Command
{
    public static InfoCommand Instance { get; } = new();

    private InfoCommand() : base("info", "<THEME-FILE>", "Describes the info contained in a theme file.")
    {
    }

    protected override void OnExecute(string[] arguments)
    {
        if (arguments.Length == 0)
        {
            ErrorMessageWidget.Display("no theme file provided. Use --help for help instructions.");
            Program.Close(false);
        }

        using JsonThemeFileHandler themeFileHandler = new(arguments[0]);

        ThemeInfoWidget.Display(themeFileHandler.ReadTheme(), true, false);
    }
}