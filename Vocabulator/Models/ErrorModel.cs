namespace Vocabulator.Models
{
    public class ErrorModel : IModel
    {
        public string Message;

        public ErrorModel(string message)
        {
            Message = message;
        }

        public bool IsStatusSuccess { get; } = false;
    }
}