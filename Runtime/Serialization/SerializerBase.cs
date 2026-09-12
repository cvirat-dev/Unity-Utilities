
using System.Reflection;

namespace UUP.Serialization
{
    public abstract class SerializerBase : ISerializer
    {
        public abstract T Deserialize<T>(string json);
        public abstract string Serialize<T>(T obj);
        public string GetFileExtension()
        {
            var attribute = GetType().GetCustomAttribute<SerializerOfTypeAttribute>();
            if (attribute == null)
            {
                throw new System.Exception($"{nameof(SerializerOfTypeAttribute)} not found");
            }

            return attribute.Type.ToString().ToLower();
        }
    }
}
