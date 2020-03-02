using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VocabulatorLibrary;
using VocabulatorLibrary.Data;
using VocabulatorWeb;
using VocabulatorWeb.Controllers;
using Xunit;

namespace VocabulatorWebTests
{
    public class HomeControllerTest
    {
        [Fact]
        public void GetView_Words_ViewWithDtoCollection()
        {
            IDto[] dtoCollection =
            {
                new WordDto("ˈhȯ(ə)rs",
                    new[]
                    {
                        new Result(
                            "a large hoofed grazing domestic mammal that is used to carry or draw loads and for riding",
                            Array.Empty<string>(), "noun"),
                        new Result("a male horse : stallion", Array.Empty<string>(), "noun"),
                        new Result("a frame that supports something (as wood while being cut)", Array.Empty<string>(),
                            "noun"),
                        new Result("to provide with a horse", Array.Empty<string>(), "verb")
                    },
                    "horse",
                    false),
                new WordDto("ˈsōp",
                    new[]
                    {
                        new Result("substance", Array.Empty<string>(), "noun"),
                        new Result("a salt of a fatty acid", Array.Empty<string>(), "noun"),
                        new Result("soap opera", Array.Empty<string>(), "noun"),
                        new Result("to rub soap over or into", Array.Empty<string>(), "verb")
                    },
                    "soap",
                    false)
            };
            var factory = new UserFacadeFactory(new Dictionary<DictionaryVersion, UserFacade>
            {
                {
                    DictionaryVersion.Test,
                    new UserFacade(
                        new VocabulatorLibrary.Dictionaries.Stub.DictionaryClient())
                }
            });
            var controller = new HomeController(null, factory);
            controller.SetUserFacade("test");
            controller.DownloadText("firstWord\r\nSecondWord");

            var response = controller.WordView();

            var viewResult = Assert.IsType<ViewResult>(response);
            var model = Assert.IsAssignableFrom<IEnumerable<IDto>>(viewResult.ViewData.Model).ToArray();
            Assert.Equal(dtoCollection, model);
        }
    }
}