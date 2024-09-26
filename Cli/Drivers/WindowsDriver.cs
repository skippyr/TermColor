using System;
using System.Runtime.InteropServices;

namespace TermColor.Cli.Drivers;

internal static class WindowsDriver
{
    [DllImport("kernel32.dll")]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    private const int STD_OUTPUT_HANDLE = -11;
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

    public static void EnableVirtualTerminalProcessing()
    {
        IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);

        if (handle == IntPtr.Zero)
        {
            return;
        }

        if (GetConsoleMode(handle, out uint mode))
        {
            SetConsoleMode(handle, mode);
        }
    }
}