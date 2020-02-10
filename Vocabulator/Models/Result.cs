using System.Collections.Generic;

namespace Vocabulator.Models
{
    public class Result
    {
        public string Definition;
        public IEnumerable<string> Examples;
        public string PartOfSpeech;

        public Result(string definition, IEnumerable<string> examples, string partOfSpeech)
        {
            Definition = definition;
            Examples = examples;
            PartOfSpeech = partOfSpeech;
        }
    }
}