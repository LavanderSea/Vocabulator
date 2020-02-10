using System;
using System.Drawing;
using System.IO;
using Vocabulator.Infrastructure;
using Vocabulator.Models;

namespace Vocabulator
{
    public class UserFacade : IDisposable
    {
        private readonly DictionaryClient _dictionaryClient;

        private readonly string _outputPath;
        private readonly StreamReader _reader;
        private readonly ExcelRepository _repository;

        public UserFacade(
            string outputPath,
            StreamReader reader,
            ExcelRepository repository,
            DictionaryClient dictionaryClient)
        {
            _outputPath = outputPath;
            _reader = reader;
            _repository = repository;
            _dictionaryClient = dictionaryClient;
        }

        public void Dispose()
        {
            _reader.Close();
            _repository.Dispose();
        }

        public static UserFacade Create(
            string inputPath,
            string outputPath,
            Color selectedColor)
        {
            var stream = File.Open(inputPath, FileMode.Open);
            var reader = new StreamReader(stream);
            var repository = new ExcelRepository();
            var dictionaryClient = new DictionaryClient();
            repository.SetColor(selectedColor);
            var userFacade = new UserFacade(outputPath, reader, repository, dictionaryClient);
            return userFacade;
        }

        public void SaveWord(Word word) => _repository.AddWord(word, _outputPath);
        public IModel GetWordModel(string word) => _dictionaryClient.Get(word);
        
        public string ReadNextWord()
        {
            var word = _reader.ReadLine();

            if (_reader.EndOfStream && string.IsNullOrEmpty(word))
                return null;

            while (!_reader.EndOfStream && string.IsNullOrEmpty(word))
                word = _reader.ReadLine();

            return word;
        }
    }
}