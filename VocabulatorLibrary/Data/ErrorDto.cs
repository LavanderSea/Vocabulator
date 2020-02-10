namespace VocabulatorLibrary.Data
{
    public class ErrorDto : IDto
    {
        public ErrorDto(string message)
        {
            Message = message;
        }

        public string Message { get; }
        public bool IsStatusSuccess { get; } = false;
    }
}