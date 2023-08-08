namespace Serialization.Serializers;

using System.Xml.Serialization;

public static class XML
{
    public static T DeepCopyXML<T>(T input)
    {
        using MemoryStream stream = new MemoryStream();

        XmlSerializer serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(stream, input);
        stream.Position = 0;

        return (T)serializer.Deserialize(stream);
    }
}