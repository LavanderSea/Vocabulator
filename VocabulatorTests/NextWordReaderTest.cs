using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vocabulator;

namespace VocabulatorTests
{
    [TestClass]
    public class NextWordReaderTest
    {
        private UserFacade CreateFacade(string input)
        {
            var buffer = Encoding.ASCII.GetBytes(input);
            var memoryStream = new MemoryStream(buffer, true);
            var reader = new StreamReader(memoryStream);
            return new UserFacade(string.Empty, reader, null, null);
        }

        [TestMethod]
        public void StreamWithTwoSpaceAndOneWord_GetWordFromStream()
        {
            var input = TestsResource.StingWithTwoSpaceAndOneWord;
            var userFacade = CreateFacade(input);
            var expectedWord = "joke";

            var actualWord = userFacade.ReadNextWord();

            Assert.AreEqual(expectedWord, actualWord);
        }

        [TestMethod]
        public void StreamWithSpaceBetweenTwoWords_GetWordsFromStream()
        {
            var input = TestsResource.StringWithSpaceBetweenTwoWords;
            var userFacade = CreateFacade(input);
            var expectedWords = new[] {"joke", "low"};

            var actualWords = new[] {userFacade.ReadNextWord(), userFacade.ReadNextWord()};

            CollectionAssert.AreEqual(expectedWords, actualWords);
        }

        [TestMethod]
        public void EmptyStream_Null()
        {
            var input = string.Empty;
            var userFacade = CreateFacade(input);

            var result = userFacade.ReadNextWord();

            Assert.IsNull(result);
        }
    }
}