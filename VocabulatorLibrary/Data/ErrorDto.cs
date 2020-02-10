namespace VocabulatorLibrary.Data
{
    public class ErrorDto : IDto
    {
        public string Message;

        public ErrorDto(string message)
        {
            Message = message;
        }

        public bool IsStatusSuccess { get; } = false;
    }
}