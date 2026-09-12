
namespace UUP.Serialization
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string json);
        string GetFileExtension();
    }
}
