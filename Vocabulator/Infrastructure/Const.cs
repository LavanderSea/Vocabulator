using System.Collections.Generic;

namespace Vocabulator.Infrastructure
{
    public static class Const
    {
        public static readonly Dictionary<string, string> Decryptions = new Dictionary<string, string>
        {
            ["adjective"] = "(adj)",
            ["noun"] = "(n)",
            ["verb"] = "(v)",
            ["expression"] = "(exp)"
        };

        public static readonly int[] ColumnWidths = {14, 9, 14, 60, 60};
        public static readonly int ColumnCount = 6;
        public static readonly char BeginningColumnSymbol = 'A';

        public static readonly string[] FirstStrings =
        {
            "Word",
            "Part of speech",
            "Transcription",
            "Definition",
            "Example"
        };
    }
}