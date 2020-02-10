using VocabulatorLibrary.Data;

namespace VocabulatorLibrary.Dictionaries
{
    public interface IParser
    {
        IDto Parse(string response);
    }
}