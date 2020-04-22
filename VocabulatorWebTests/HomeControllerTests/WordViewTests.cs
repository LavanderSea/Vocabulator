using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VocabulatorLibrary.Data;
using Xunit;

namespace VocabulatorWebTests.HomeControllerTests
{
    public class WordViewTests : HomeControllerTests
    {
        [Fact]
        public void GetView_Words_ViewWithDtoCollection()
        {
            const string text = "firstWord\r\nSecondWord";
            var dtoCollection = GetTestDtoCollection();
            var controller = GetTestController();

            controller.DownloadText(text, text.Length);
            var response = controller.WordView();

            var viewResult = Assert.IsType<ViewResult>(response);
            var model = Assert.IsAssignableFrom<IEnumerable<IDto>>(viewResult.ViewData.Model);
            Assert.Equal(dtoCollection, model);
        }
    }
}