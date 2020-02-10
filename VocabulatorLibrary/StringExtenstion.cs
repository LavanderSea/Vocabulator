namespace VocabulatorLibrary
{
    public static class StringExtenstion
    {
        public static string ToValidFormat(this string word)
        {
            var validWord = word.Replace("to ", string.Empty);
            return validWord;
        }
    }
}