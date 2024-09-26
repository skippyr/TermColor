using System.ComponentModel;
using System.Diagnostics;

namespace TermColor.Desktop.Vcs;

internal static class Git
{
    public static Developer User { get; } = new() { Name = GetConfigKey("user.name"), Email = GetConfigKey("user.email") };
    public static Repository Repository { get; } = new(GetProcessOutput("rev-parse --show-toplevel"), GetProcessOutput("remote get-url origin"));

    private static string? GetProcessOutput(string command)
    {
        try
        {
            Process? process = Process.Start(new ProcessStartInfo { FileName = "git", Arguments = command, RedirectStandardOutput = true, RedirectStandardError = true });

            if (process == null)
            {
                return null;
            }

            process.WaitForExit();

            return process.ExitCode != 0 ? null : process.StandardOutput.ReadToEnd().TrimEnd();
        }
        catch (Win32Exception)
        {
            return null;
        }
    }

    private static string? GetConfigKey(string key)
    {
        return GetProcessOutput($"config {key}");
    }
}