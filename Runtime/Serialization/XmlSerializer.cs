using System.IO;
using System.Text;

namespace UUP.Serialization
{
    [SerializerOfType(SerializerType.Xml)]
    public class XmlSerializer : SerializerBase
    {
        public override T Deserialize<T>(string xml)
        {
            System.Xml.Serialization.XmlSerializer serializer = new(typeof(T));
            return (T)serializer.Deserialize(new StringReader(xml));

        }
        public override string Serialize<T>(T obj)
        {
            System.Xml.Serialization.XmlSerializer serializer = new(typeof(T));
            StringBuilder sb = new();
            StringWriter writer = new(sb);
            serializer.Serialize(writer, obj);
            return sb.ToString();
        }

    }
}
