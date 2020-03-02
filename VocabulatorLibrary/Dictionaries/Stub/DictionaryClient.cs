using System;
using System.Collections.Generic;
using VocabulatorLibrary.Data;

namespace VocabulatorLibrary.Dictionaries.Stub
{
    public class DictionaryClient : IDictionaryClient
    {
        private readonly IEnumerator<IDto> _dto;

        public DictionaryClient()
        {
            IEnumerable<IDto> dtoCollection = new[]
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

            _dto = dtoCollection.GetEnumerator();
            _dto.MoveNext();
        }

        public IDto GetWord(string desiredValue)
        {
            IDto dto;
            try
            {
                dto = _dto.Current;
                _dto.MoveNext();
            }
            catch (InvalidOperationException)
            {
                _dto.Reset();
                _dto.MoveNext();
                dto = _dto.Current;
            }

            return dto;
        }
    }
}