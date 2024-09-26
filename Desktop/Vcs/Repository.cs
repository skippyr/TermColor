using System;
using System.IO;
using System.Linq;

namespace TermColor.Desktop.Vcs;

public sealed record Repository(string? Path, string? UpstreamUrl)
{
    public string? Name { get; } = Path == null ? null : System.IO.Path.GetFileName(Path);
    public string? License { get; } = GetLicense(Path);

    private static string? GetLicense(string? path)
    {
        string? file = path == null ? null : System.IO.Path.Combine(path, "LICENSE");

        if (!File.Exists(file))
        {
            return null;
        }

        try
        {
            string? firstLine = File.ReadLines(file).First();

            return firstLine.Contains("license", StringComparison.CurrentCultureIgnoreCase) ? firstLine.Trim() : null;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}