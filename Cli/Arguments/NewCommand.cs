using System;
using System.IO;

using TermColor.Cli.Design;
using TermColor.Cli.Widgets.Display;
using TermColor.Cli.Widgets.Input;
using TermColor.Desktop.Vcs;
using TermColor.FileSystem;
using TermColor.Transformers;

namespace TermColor.Cli.Arguments;

internal sealed class NewCommand : Command
{
    public static NewCommand Instance { get; } = new();

    private NewCommand() : base("new", "<THEME-FILE>", "Creates a new theme file interactively.")
    {
    }

    protected override void OnExecute(string[] arguments)
    {
        if (arguments.Length == 0)
        {
            ErrorMessageWidget.Display("no theme file specified. Use --help for help instructions.");
            Program.Close(false);
        }

        if (File.Exists(arguments[0]))
        {
            if (!BoolInputWidget.Read("The file provided already exists. Do you want to overwrite it?", false))
            {
                return;
            }

            Console.WriteLine();
        }

        using JsonThemeFileHandler themeFileHandler = new(arguments[0], true);

        Console.WriteLine("If needed, use [Ctrl] + [c] to cancel this command.");

        Theme theme;

        while (true)
        {
            Console.WriteLine();

            theme = new Theme
            {
                Name =
                    StringInputWidget.Read("Enter the name of the theme",
                        StringTransformer.TransformToSpacedTitleCase(Git.Repository.Name ?? Path.GetFileNameWithoutExtension(arguments[0]))),
                Author = new Developer
                {
                    Name = StringInputWidget.Read("Enter the name of the author", Git.User.Name),
                    Email = EmailInputWidget.Read("Enter the e-mail of the author", Git.User.Email)
                },
                License = StringInputWidget.Read("Enter the license of the theme", Git.Repository.License ?? "BSD-3-Clause License"),
                UpstreamUrl = UrlInputWidget.Read("Enter the upstream url of the theme", Git.Repository.UpstreamUrl)
            };

            Console.WriteLine();
            Console.WriteLine("This is the data collected about your theme:");
            ThemeInfoWidget.Display(theme, false, true);
            Console.WriteLine();

            if (BoolInputWidget.Read("Is the information correct? If not, you will repeat this part of form", true))
            {
                break;
            }
        }

        if (!BoolInputWidget.Read("Do you want to add the palette of the theme now? If not, it will use a generic one"))
        {
            goto WriteFile;
        }

        while (true)
        {
            Console.WriteLine();

            theme.Palette.DarkColors.Black = HexColorInputWidget.Read("Enter the dark black color of the theme", theme.Palette.DarkColors.Black);
            theme.Palette.DarkColors.Red = HexColorInputWidget.Read("Enter the dark red color of the theme", theme.Palette.DarkColors.Red);
            theme.Palette.DarkColors.Green = HexColorInputWidget.Read("Enter the dark green color of the theme", theme.Palette.DarkColors.Green);
            theme.Palette.DarkColors.Yellow = HexColorInputWidget.Read("Enter the dark yellow color of the theme", theme.Palette.DarkColors.Yellow);
            theme.Palette.DarkColors.Blue = HexColorInputWidget.Read("Enter the dark blue color of the theme", theme.Palette.DarkColors.Blue);
            theme.Palette.DarkColors.Magenta = HexColorInputWidget.Read("Enter the dark magenta color of the theme", theme.Palette.DarkColors.Magenta);
            theme.Palette.DarkColors.Cyan = HexColorInputWidget.Read("Enter the dark cyan color of the theme", theme.Palette.DarkColors.Cyan);
            theme.Palette.DarkColors.White = HexColorInputWidget.Read("Enter the dark white color of the theme", theme.Palette.DarkColors.White);

            Console.WriteLine();

            theme.Palette.LightColors.Black = HexColorInputWidget.Read("Enter the light black color", theme.Palette.LightColors.Black);

            Console.WriteLine();

            if (BoolInputWidget.Read("Do you want to copy the dark colors to the remaining light colors?", true))
            {
                theme.Palette.LightColors.Red = theme.Palette.DarkColors.Red;
                theme.Palette.LightColors.Green = theme.Palette.DarkColors.Green;
                theme.Palette.LightColors.Yellow = theme.Palette.DarkColors.Yellow;
                theme.Palette.LightColors.Blue = theme.Palette.DarkColors.Blue;
                theme.Palette.LightColors.Magenta = theme.Palette.DarkColors.Magenta;
                theme.Palette.LightColors.Cyan = theme.Palette.DarkColors.Cyan;
                theme.Palette.LightColors.White = theme.Palette.DarkColors.White;

                goto ColorsConfirmation;
            }

            Console.WriteLine();

            theme.Palette.LightColors.Red = HexColorInputWidget.Read("Enter the light red color of the theme", theme.Palette.LightColors.Red);
            theme.Palette.LightColors.Green = HexColorInputWidget.Read("Enter the light green color of the theme", theme.Palette.LightColors.Green);
            theme.Palette.LightColors.Yellow = HexColorInputWidget.Read("Enter the light yellow color of the theme", theme.Palette.LightColors.Yellow);
            theme.Palette.LightColors.Blue = HexColorInputWidget.Read("Enter the light blue color of the theme", theme.Palette.LightColors.Blue);
            theme.Palette.LightColors.Magenta = HexColorInputWidget.Read("Enter the light magenta color of the theme", theme.Palette.LightColors.Magenta);
            theme.Palette.LightColors.Cyan = HexColorInputWidget.Read("Enter the light cyan color of the theme", theme.Palette.LightColors.Cyan);
            theme.Palette.LightColors.White = HexColorInputWidget.Read("Enter the light white color of the theme", theme.Palette.LightColors.White);

        ColorsConfirmation:
            Console.WriteLine();
            Console.WriteLine("This is the data collected about your theme:");
            ThemeInfoWidget.Display(theme, true, true);
            Console.WriteLine();

            if (BoolInputWidget.Read("Is the information correct? If not, you will repeat this part of form", true))
            {
                break;
            }
        }

    WriteFile:
        Console.WriteLine();
        themeFileHandler.WriteTheme(theme);
        Console.WriteLine("Created your brand new theme file.");
    }
}