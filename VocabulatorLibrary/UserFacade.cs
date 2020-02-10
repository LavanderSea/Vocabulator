using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VocabulatorLibrary.Dictionaries;
using VocabulatorLibrary.Data;


namespace VocabulatorLibrary
{
    public class UserFacade
    {
        private readonly IDictionaryClient _dictionaryClient;

        public UserFacade(IDictionaryClient dictionaryClient)
        {
            _dictionaryClient = dictionaryClient;
        }

        public IEnumerable<IDto> GetDtos(IEnumerable<string> words)
        {
            var values = words.Select(word => _dictionaryClient.GetWord(word.ToValidFormat()));
            return values;
        }

        public void CreateResultFile(IEnumerable<Word> words, string path)
        {
            using (var writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                foreach (var word in words)
                    writer.WriteLine(
                        $"{word.Value},{word.PartOfSpeech},{word.Transcription},{word.Definition},{word.Example}");
            }
        }
    }
}