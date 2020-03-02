using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VocabulatorLibrary.Data;

namespace VocabulatorLibrary.Dictionaries.WordApi
{
    public class ResponseParser : IParser
    {
        public IDto Parse(string response)
        {
            var jObject = JObject.Parse(response);
            try
            {
                var results = new List<Result>();
                foreach (var result in jObject["results"])
                {
                    var examples = result["examples"]?.Select(example => example.ToString()) ?? Array.Empty<string>();
                    results.Add(new Result(
                        result["definition"].ToString(),
                        examples,
                        result["partOfSpeech"].ToString()));
                }

                string pronunciation;
                try
                {
                    pronunciation = jObject["pronunciation"]["all"].ToString();
                }
                catch (InvalidOperationException)
                {
                    pronunciation = jObject["pronunciation"].ToString();
                }

                return new WordDto(
                    pronunciation,
                    results,
                    jObject["word"].ToString(),
                    false);
            }
            catch (Exception exception)
                when (exception is ArgumentNullException || exception is NullReferenceException)
            {
                return new ErrorDto(jObject["message"].ToString());
            }
        }
    }
}