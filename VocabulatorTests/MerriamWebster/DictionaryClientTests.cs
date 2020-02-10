using System;
using NUnit.Framework;
using VocabulatorLibrary.Data;
using DictionaryClient = VocabulatorLibrary.Dictionaries.MerriamWebster.DictionaryClient;
using ResponseParser = VocabulatorLibrary.Dictionaries.MerriamWebster.ResponseParser;

namespace VocabulatorTests.MerriamWebster
{
    public class DictionaryClientTests
    {
        private DictionaryClient _dictionaryClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dictionaryClient = new DictionaryClient(new ResponseParser());
        }

        [Test]
        public void GetWordData_Word_CorrectResponse()
        {
            var requestWord = "horse";
            var dto = new WordDto("ˈhȯ(ə)rs",
                new[]
                {
                    new Result("a large hoofed grazing domestic mammal that is used to carry or draw loads and for riding", Array.Empty<string>(), "noun"),
                    new Result("a male horse : stallion", Array.Empty<string>(), "noun"),
                    new Result("a frame that supports something (as wood while being cut)", Array.Empty<string>(), "noun"),
                    new Result("to provide with a horse", Array.Empty<string>(), "verb"),
                },
                "horse",
                false);

            var result = _dictionaryClient.GetWord(requestWord);

            Assert.AreEqual(dto, result);
        }

        [Test]
        public void GetWordData_IncorrectWord_ErrorResponse()
        {
            var requestWord = "foobar";
            var dto = new ErrorDto("Word didn't found");

            var result = _dictionaryClient.GetWord(requestWord);

            Assert.AreEqual(dto, result);
        }

        [Test]
        public void GetWordData_EmptyString_ErrorResponse()
        {
            var request = string.Empty;
            var error = new ErrorDto("Wrong response format");

            var result = _dictionaryClient.GetWord(request);

            Assert.AreEqual(error, result);
        }

        [Test]
        public void GetPhraseData_IncorrectPhrase_ErrorResponse()
        {
            var request = "get off your high horse";
            var error = new ErrorDto("Word didn't found");

            var result = _dictionaryClient.GetWord(request);

            Assert.AreEqual(error, result);
        }
        
        [Test]
        public void GetPhraseData_CorrectPhrase_CorrectResponse()
        {
            var request = "hold on";
            var error = new WordDto(
                string.Empty,
                new[]
                {
                    new Result("to keep a hold", Array.Empty<string>(), "verb"),
                    new Result("wait:1", Array.Empty<string>(), "verb")
                },
                "hold on",
                false);

            var result = _dictionaryClient.GetWord(request);

            Assert.AreEqual(error, result);
        }

    }
}
