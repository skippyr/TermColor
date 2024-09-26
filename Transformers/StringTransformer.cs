using System;
using System.Text.RegularExpressions;

namespace TermColor.Transformers;

internal static partial class StringTransformer
{
    [GeneratedRegex(@"[-_]+|\s+|(?<=[a-z])(?=[A-Z])")]
    private static partial Regex SpacedTitleCaseRegex();

    public static string TransformToSpacedTitleCase(string str)
    {
        string treatedStr = SpacedTitleCaseRegex().Replace(str, " ");
        string[] words = treatedStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int offset = 0; offset < words.Length; offset++)
        {
            words[offset] = char.ToUpper(words[offset][0]) + words[offset][1..].ToLower();
        }

        return string.Join(' ', words);
    }
}