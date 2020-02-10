using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VocabulatorLibrary.Data;

namespace VocabulatorLibrary.Dictionaries.MerriamWebster
{
    public class ResponseParser : IParser
    {
        public IDto Parse(string response)
        {
            if (string.IsNullOrEmpty(response))
                return new ErrorDto("Empty response");

            JArray tokens;
            try
            {
                tokens = JArray.Parse(response);
            }
            catch (JsonReaderException)
            {
                return new ErrorDto("Wrong response format");
            }

            if (!tokens.Any() || !tokens.First().Children().Any()) return new ErrorDto("Word didn't found");

            var results = new List<Result>();

            var pronunciation = tokens.First()["hwi"]?["prs"]?.First()["mw"]?.ToString() ?? string.Empty;
            var word = tokens.First()["hwi"]?["hw"]?.ToString();

            foreach (var token in tokens)
            {
                if (token["hwi"]["hw"].ToString().Equals(word))
                {
                    var partOfSpeech = token["fl"].ToString();
                    results.AddRange(token["shortdef"]
                        .Select(r => new Result(r.ToString(), Array.Empty<string>(), partOfSpeech)));
                }
            }

            return new WordDto(pronunciation, results, word, false);
        }
    }
}