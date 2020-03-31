namespace VocabulatorWeb.Serializers
{
    public interface IDeserializer<T>
    {
        T Deserialize(string str);
    }
}
