using System.Collections.Generic;

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
        public string PartOfSpeech { get; }
    }
}