using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace VocabulatorWebTests.HomeControllerTests
{
    public class SetUserFacadeTests : HomeControllerTests
    {
        [Theory]
        [InlineData(null, "Test")]
        [InlineData("", "Test")]
        [InlineData("test", "Test")]
        [InlineData("whatever", "Test")]
        [InlineData("mw", "MerriamWebster")]
        [InlineData("wa", "WordApi")]
        public void SetUserFacade_UserFacadeType_Ok(string type, string nameOfType)
        {
            var controller = GetController();

            var response = controller.SetUserFacade(type);

            var okResult = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(nameOfType + " dictionary has chosen", okResult.Value);
        }
    }
}