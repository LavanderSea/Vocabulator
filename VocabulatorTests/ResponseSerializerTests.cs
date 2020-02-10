using System;
using System.Collections.Generic;
using NUnit.Framework;
using VocabulatorLibrary.Data;
using VocabulatorWeb.Serializers;

namespace VocabulatorTests
{
    public class ResponseSerializerTests
    {
        private ResponseSerializer _serializer;

        [OneTimeSetUp]
        public void Setup()
        {
            _serializer = new ResponseSerializer();
        }

        public IEnumerable<IDto> CreateTestDtoCollection()
        {
            var testWordDto = new WordDto(
                @"ˈroʊ.bɑːt",
                new List<Result>
                {
                    new Result(
                        "test_definition_1",
                        Array.Empty<string>(),
                        "test_pos"),
                    new Result(
                        "test_definition_2",
                        new[] {"test_example_1", "test_example_2"},
                        "test_pos")
                },
                "test_word",
                false);
            var testErrorDto = new ErrorDto("test_message");
            return new IDto[] {testWordDto, testErrorDto};
        }

        [Test]
        public void Serialize_IDtoCollectionWithWordDtoAndErrorDto_ReturnsSerializedString()
        {
            var dtoCollection = CreateTestDtoCollection();

            var result = _serializer.Serialize(dtoCollection);

            var expected = TestsResource.CollectionWithWordDtoAndErrorDtoJson;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Serialize_Null_NullArgumentException()
        {
            Assert.Throws<ArgumentNullException>(delegate { _serializer.Serialize(null); });
        }

        [Test]
        public void Serialize_EmptyCollection_EmptyString()
        {
            var dtoCollection = Array.Empty<IDto>();

            var result = _serializer.Serialize(dtoCollection);

            var expected = "[]";
            Assert.AreEqual(expected, result);
        }
    }
}