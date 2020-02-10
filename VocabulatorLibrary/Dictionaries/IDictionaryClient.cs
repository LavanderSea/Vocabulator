using VocabulatorLibrary.Data;

namespace VocabulatorLibrary.Dictionaries
{
    public interface IDictionaryClient
    {
        IDto GetWord(string word);
    }
}