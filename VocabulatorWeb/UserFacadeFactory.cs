using System.Collections.Generic;
using VocabulatorLibrary;

namespace VocabulatorWeb
{
    public class UserFacadeFactory
    {
        private readonly Dictionary<DictionaryVersion, UserFacade> _facades;
        public DictionaryVersion Type { private set; get; }

        public UserFacadeFactory(Dictionary<DictionaryVersion, UserFacade> facades)
        {
            _facades = facades;
        }

        public void SetType(string type)
        {
            Type = type switch
                {
                "mw" => DictionaryVersion.MerriamWebster,
                "wa" => DictionaryVersion.WordApi,
                _ => DictionaryVersion.Test,
                };
        }

        public UserFacade Create()
        {
            return Create(Type);
        }

        public UserFacade Create(DictionaryVersion type)
        {
            return _facades[type];
        }
    }
}