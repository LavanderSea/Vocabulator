using System.Net;
using RestSharp;
using VocabulatorLibrary.Data;

namespace VocabulatorLibrary.Dictionaries
{
    public class DictionaryClient : IDictionaryClient
    {
        private readonly ResponseParser _responseParser;

        public DictionaryClient(ResponseParser responseParser)
        {
            _responseParser = responseParser;
        }

        public IDto GetWord(string word)
        {
            var client = new RestClient(DictionaryResource.Url + word);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "wordsapiv1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", DictionaryResource.Key);
            var response = client.Execute(request);
            var model = _responseParser.ParseResponse(response.Content);
            return response.StatusCode == HttpStatusCode.BadRequest
                ? new ErrorDto("Bad request")
                : model;
        }
    }
}