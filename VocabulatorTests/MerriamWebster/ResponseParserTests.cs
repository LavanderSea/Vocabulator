using System;
using NUnit.Framework;
using VocabulatorLibrary.Data;
using ResponseParser = VocabulatorLibrary.Dictionaries.MerriamWebster.ResponseParser;

namespace VocabulatorTests.MerriamWebster
{
    public class ResponseParserTests
    {
        private ResponseParser _parser;

        [OneTimeSetUp]
        public void SetUp()
        {
            _parser = new ResponseParser();
        }

        [Test]
        public void Parse_JsonWithTwoDefinitions_WordDto()
        {
            var json = TestsResource.WordWithTwoDefinitionsJson.Replace("\n", "");
            var dto = new WordDto("ˈsōp",
                new[]
                {
                    new Result("substance", Array.Empty<string>(), "noun"),
                    new Result("a salt of a fatty acid", Array.Empty<string>(), "noun"),
                    new Result("soap opera", Array.Empty<string>(), "noun"),
                    new Result("to rub soap over or into", Array.Empty<string>(), "verb"),
                },
                "soap",
                false);


            var result = _parser.Parse(json) as WordDto;

            Assert.AreEqual(dto, result);
        }

        [Test]
        public void Parse_EmptyString_ErrorDto()
        {
            var json = string.Empty;
            var error = new ErrorDto("Empty response");

            var result = _parser.Parse(json);

            Assert.AreEqual(error, result);
        }

        [Test]
        public void Parse_IncorrectJson_ErrorDto()
        {
            var json = "[";
            var error = new ErrorDto("Wrong response format");

            var result = _parser.Parse(json);

            Assert.AreEqual(error, result);
        }
    }
}