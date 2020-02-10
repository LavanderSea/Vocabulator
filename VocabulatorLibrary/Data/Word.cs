namespace VocabulatorLibrary.Data
{
    public class Word
    {
        public Word(string value, string partOfSpeech, string transcription, string definition, string example)
        {
            Value = value;
            PartOfSpeech = partOfSpeech;
            Transcription = transcription;
            Definition = definition;
            Example = example;
        }

        public string Value { get; }
        public string PartOfSpeech { get; }
        public string Transcription { get; }
        public string Definition { get; }
        public string Example { get; }
    }
}