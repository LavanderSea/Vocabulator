using System.Collections.Generic;

namespace VocabulatorLibrary.Data
{
    public class WordDto : IDto
    {
        public WordDto(string pronunciation, IEnumerable<Result> results, string word, bool isProcessed)
        {
            Pronunciation = pronunciation;
            Results = results;
            Word = word;
            IsProcessed = isProcessed;
        }

        public bool IsProcessed { get; set; }
        public string Pronunciation { get; }
        public IEnumerable<Result> Results { get; }
        public string Word { get; }
        public bool IsStatusSuccess { get; } = true;
    }
}