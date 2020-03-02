using System.Collections.Generic;
using VocabulatorLibrary;

namespace VocabulatorWeb
{
    public class UserFacadeFactory
    {
        private readonly Dictionary<DictionaryVersion, UserFacade> _facades;
        private DictionaryVersion _type;

        public UserFacadeFactory(Dictionary<DictionaryVersion, UserFacade> facades)
        {
            _facades = facades;
        }

        public void SetType(string type)
        {
            _type = type switch
                {
                "mw" => DictionaryVersion.MerriamWebster,
                "wa" => DictionaryVersion.WordApi,
                _ => DictionaryVersion.Test,
                };
        }

        public UserFacade Create()
        {
            return Create(_type);
        }

        public UserFacade Create(DictionaryVersion type)
        {
            return _facades[type];
        }
    }
}