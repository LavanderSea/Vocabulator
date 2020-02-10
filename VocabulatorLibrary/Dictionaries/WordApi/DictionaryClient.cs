using System.Net;
using RestSharp;
using VocabulatorLibrary.Data;

namespace VocabulatorLibrary.Dictionaries.WordApi
{
    public class DictionaryClient : IDictionaryClient
    {
        private readonly ResponseParser _responseParser;

        public DictionaryClient(ResponseParser responseParser)
        {
            _responseParser = responseParser;
        }

        public IDto GetWord(string desiredValue)
        {
            var client = new RestClient(DictionaryResource.Url + desiredValue);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "wordsapiv1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", DictionaryResource.Key);
            var response = client.Execute(request);
            var dto = _responseParser.Parse(response.Content);
            return response.StatusCode == HttpStatusCode.BadRequest
                ? new ErrorDto("Bad request")
                : dto;
        }
    }
}