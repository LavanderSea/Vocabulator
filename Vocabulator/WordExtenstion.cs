using Vocabulator.Infrastructure;

namespace Vocabulator
{
    public static class WordExtenstion
    {
        public static string ToValidFormat(this string word)
        {
            var validWord = word.Replace("to ", string.Empty);

            foreach (var decryption in Const.Decryptions)
                if (word.Contains(decryption.Value))
                    validWord = validWord.Replace(decryption.Value, string.Empty);

            return validWord;
        }

        public static string GetPartOfSpeech(this string word)
        {
            var partOfSpeech = "unidentified";

            foreach (var decryption in Const.Decryptions)
                if (word.Contains(decryption.Value))
                    partOfSpeech = decryption.Key;

            return partOfSpeech;
        }
    }
}