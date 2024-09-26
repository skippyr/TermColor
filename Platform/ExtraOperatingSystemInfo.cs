using System;

namespace TermColor.Platform;

internal static class ExtraOperatingSystemInfo
{
    public static string Name { get; } = OperatingSystem.IsWindows() ? "Windows" : OperatingSystem.IsMacOS() ? "MacOS" : "Linux";
}