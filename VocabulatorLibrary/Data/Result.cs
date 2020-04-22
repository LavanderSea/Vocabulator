using System.Collections.Generic;
using System.Linq;

namespace VocabulatorLibrary.Data
{
    public class Result
    {
        public Result(string definition, IEnumerable<string> examples, string partOfSpeech)
        {
            Definition = definition;
            Examples = examples;
            PartOfSpeech = partOfSpeech;
        }

        public string Definition { get; }
        public IEnumerable<string> Examples { get; }

        protected bool Equals(Result other)
        {
            return string.Equals(Definition, other.Definition) && 
                   Examples.SequenceEqual(other.Examples) &&
                   string.Equals(PartOfSpeech, other.PartOfSpeech);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Result) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Definition.GetHashCode();
                hashCode = (hashCode * 397) ^ Examples.GetHashCode();
                hashCode = (hashCode * 397) ^ PartOfSpeech.GetHashCode();
                return hashCode;
            }
        }

        public string PartOfSpeech { get; }
    }
}