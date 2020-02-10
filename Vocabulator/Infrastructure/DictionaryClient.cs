using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using Vocabulator.Models;

namespace Vocabulator.Infrastructure
{
    public class DictionaryClient
    {
        public IModel Get(string word)
        {
            var client = new RestClient(DictionaryResource.Url + word);
            var request = CreateRestRequest();
            var response = client.Execute(request);
            var jObject = JObject.Parse(response.Content);
            return response.StatusCode == HttpStatusCode.BadRequest
                ? new ErrorModel("Bad request")
                : ParseResponse(jObject);
        }

        public IModel ParseResponse(JObject jObject)
        {
            IModel model;
            try
            {
                var results = new List<Result>();
                foreach (var result in jObject["results"])
                {
                    var examples = result["examples"]?.Select(example => example.ToString());
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

                model = new WordModel(
                    pronunciation,
                    results,
                    jObject["word"].ToString(),
                    false);
            }
            catch (Exception exception)
                when (exception is ArgumentNullException || exception is NullReferenceException)
            {
                model = new ErrorModel(jObject["message"].ToString());
            }

            return model;
        }

        private RestRequest CreateRestRequest()
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "wordsapiv1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", DictionaryResource.Key);
            return request;
        }
    }
}