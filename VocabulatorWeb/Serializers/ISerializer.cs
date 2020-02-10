using System.Collections.Generic;
using VocabulatorLibrary.Data;

namespace VocabulatorWeb.Serializers
{
    public interface ISerializer
    {
        string Serialize(IEnumerable<IDto> dtoCollection);
    }
}
