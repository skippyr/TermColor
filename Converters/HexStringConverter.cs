using System;
using System.Globalization;

namespace TermColor.Converters;

internal static class HexStringConverter
{
    public static int Convert(string hexColor)
    {
        return hexColor.StartsWith('#') && hexColor.Length == 7 && int.TryParse(hexColor[1..], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int value)
            ? value
            : throw new FormatException();
    }
}