namespace VocabulatorWeb.Serializers
{
    public interface ISerializer<T>
    {
        string Serialize(T item);
    }
}
