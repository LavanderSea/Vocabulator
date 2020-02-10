using System.Collections.Generic;
using System.Linq;

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

        protected bool Equals(WordDto other)
        {
            return IsProcessed == other.IsProcessed &&
                   IsStatusSuccess == other.IsStatusSuccess &&
                   string.Equals(Pronunciation, other.Pronunciation) &&
                   Results.SequenceEqual(other.Results) &&
                   string.Equals(Word, other.Word);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((WordDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IsProcessed.GetHashCode();
                hashCode = (hashCode * 397) ^ IsStatusSuccess.GetHashCode();
                hashCode = (hashCode * 397) ^ (Pronunciation != null ? Pronunciation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Results != null ? Results.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Word != null ? Word.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}