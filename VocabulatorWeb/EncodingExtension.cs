using System;
using System.Text.RegularExpressions;

namespace VocabulatorWeb
{
    public static class EncodingExtension
    {
        public static string ConvertFromUnicode(this string input) => Regex.Replace(
            input,
            @"\\u([0-9A-Fa-f]{4})",
            m => "" + (char) Convert.ToInt32(m.Groups[1].Value, 16));
    }
}