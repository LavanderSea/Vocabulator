using System.Net;
using RestSharp;
using VocabulatorLibrary.Data;

namespace VocabulatorLibrary.Dictionaries.MerriamWebster
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
            var value = desiredValue.Replace(" ", "-");
            var url = DictionaryResource.MerriamWebsterUrl.Replace("{desiredValue}", value);
            var key = DictionaryResource.MerriamWebsterKey;
            var client = new RestClient(url + key);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            var dto = _responseParser.Parse(response.Content);
            return response.StatusCode == HttpStatusCode.BadRequest
                ? new ErrorDto("Bad request")
                : dto;
        }
    }
}