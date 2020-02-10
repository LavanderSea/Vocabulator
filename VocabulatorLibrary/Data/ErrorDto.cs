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

        protected bool Equals(ErrorDto other)
        {
            return IsStatusSuccess == other.IsStatusSuccess && string.Equals(Message, other.Message);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ErrorDto) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (IsStatusSuccess.GetHashCode() * 397) ^ Message.GetHashCode();
            }
        }
    }
}