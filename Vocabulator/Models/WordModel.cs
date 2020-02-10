using System.Collections.Generic;

namespace Vocabulator.Models
{
    public class WordModel : IModel
    {
        public bool IsProcessed;
        public string Pronunciation;
        public IEnumerable<Result> Results;
        public string Word;

        public WordModel(string pronunciation, IEnumerable<Result> results, string word, bool isProcessed)
        {
            Pronunciation = pronunciation;
            Results = results;
            Word = word;
            IsProcessed = isProcessed;
        }

        public bool IsStatusSuccess { get; } = true;
    }
}