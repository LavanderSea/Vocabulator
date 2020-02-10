using System.Collections.Generic;

namespace VocabulatorLibrary.Data
{
    public class WordDto : IDto
    {
        public bool IsProcessed;
        public string Pronunciation;
        public IEnumerable<Result> Results;
        public string Word;

        public WordDto(string pronunciation, IEnumerable<Result> results, string word, bool isProcessed)
        {
            Pronunciation = pronunciation;
            Results = results;
            Word = word;
            IsProcessed = isProcessed;
        }

        public bool IsStatusSuccess { get; } = true;
    }
}