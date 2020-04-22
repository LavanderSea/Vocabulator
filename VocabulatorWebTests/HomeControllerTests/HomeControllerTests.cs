using Moq;
using System;
using System.Collections.Generic;
using VocabulatorLibrary;
using VocabulatorLibrary.Data;
using VocabulatorWeb;
using VocabulatorWeb.Controllers;
using VocabulatorWeb.Serializers;
using Dictionaries = VocabulatorLibrary.Dictionaries;

namespace VocabulatorWebTests.HomeControllerTests
{
    public abstract class HomeControllerTests
    {
        private protected IEnumerable<IDto> GetTestDtoCollection()
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
                        new Result("substance", new List<string> {"first", "second"}, "noun"),
                        new Result("a salt of a fatty acid", Array.Empty<string>(), "noun"),
                        new Result("soap opera", Array.Empty<string>(), "noun"),
                        new Result("to rub soap over or into", Array.Empty<string>(), "verb")
                    },
                    "soap",
                    false)
            };
            return dtoCollection;
        }

        private protected HomeController GetController()
        {
            var factory = GetUserFacadeFactory();
            var mock = new Mock<IDeserializer<IEnumerable<Word>>>();
            return new HomeController(null, factory, mock.Object);

        }
        private protected UserFacadeFactory GetUserFacadeFactory()
        {
            return new UserFacadeFactory(new Dictionary<DictionaryVersion, UserFacade>
            {
                {
                    DictionaryVersion.Test,
                    new UserFacade(
                        new Dictionaries.Stub.DictionaryClient())
                },
                {
                    DictionaryVersion.MerriamWebster,
                    new UserFacade(
                        new Dictionaries.MerriamWebster.DictionaryClient(
                            new Dictionaries.MerriamWebster.ResponseParser()))
                },
                {
                    DictionaryVersion.WordApi,
                    new UserFacade(
                        new Dictionaries.WordApi.DictionaryClient(
                            new Dictionaries.WordApi.ResponseParser()))
                }
            });
        }

        private protected HomeController GetTestController()
        {
            var controller = GetController();
            controller.SetUserFacade("test");
            return controller;
        }
    }
}