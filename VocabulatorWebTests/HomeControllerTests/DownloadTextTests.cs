using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace VocabulatorWebTests.HomeControllerTests
{
    public class DownloadTextTests : HomeControllerTests
    {
        [Theory]
        [InlineData("one1")]
        [InlineData("one)")]
        [InlineData("one!")]
        [InlineData("один")]
        [InlineData("ОДИН")]
        public void DownloadText_TextWithIncorrectSymbols_BadRequest(string text)
        {
            var controller = GetTestController();

            var response = controller.DownloadText(text, text.Length);

            var badRequest = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, badRequest.StatusCode);
            Assert.Equal("Include incorrect symbols", badRequest.Value);
        }

        [Theory]
        [InlineData("one\rtwo")]
        [InlineData("one\ntwo")]
        [InlineData("one\r\ntwo")]
        [InlineData("one two")]
        [InlineData("one\'two")]
        [InlineData("one-two")]
        public void DownloadText_TextWithCorrectSymbols_Ok(string text)
        {
            var controller = GetTestController();

            var response = controller.DownloadText(text, text.Length);

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public void DownloadText_TextWithEmptyLength_BadRequest()
        {
            var controller = GetTestController();

            var response = controller.DownloadText(string.Empty, null);

            var badRequest = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, badRequest.StatusCode);
            Assert.Equal("No Content-Length header founded", badRequest.Value);
        }

        [Fact]
        public void DownloadText_TextWithZeroLength_BadRequest()
        {
            var controller = GetTestController();

            var response = controller.DownloadText(string.Empty, 0);

            var badRequest = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, badRequest.StatusCode);
            Assert.Equal("Empty request", badRequest.Value);
        }


        [Fact]
        public void DownloadText_TextWithUnacceptableLength_BadRequest()
        {
            var controller = GetTestController();

            var response = controller.DownloadText(string.Empty, 2001);

            var badRequest = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(400, badRequest.StatusCode);
            Assert.Equal("Too much words", badRequest.Value);
        }
    }
}