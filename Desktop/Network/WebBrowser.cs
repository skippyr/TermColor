using System.ComponentModel;
using System.Diagnostics;

namespace TermColor.Desktop.Network;

internal static class WebBrowser
{
    public static void Browse(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true })?.WaitForExit();
        }
        catch (Win32Exception)
        {
        }
    }
}