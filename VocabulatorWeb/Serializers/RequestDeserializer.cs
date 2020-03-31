using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VocabulatorLibrary.Data;

namespace VocabulatorWeb.Serializers
{
    public class RequestDeserializer : IDeserializer<IEnumerable<Word>>
    {
        public IEnumerable<Word> Deserialize(string jWords)
        {
            var words = JArray.Parse(jWords);
            return words.Select(word => new Word(
                word["value"].ToString(),
                word["partOfSpeech"].ToString(),
                word["transcription"].ToString(),
                word["definition"].ToString(),
                word["example"].ToString()));
        }
    }
}