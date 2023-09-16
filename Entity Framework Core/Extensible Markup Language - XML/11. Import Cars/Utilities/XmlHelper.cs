namespace CarDealer.Utilities;

using System.IdentityModel.Tokens.Jwt;
using System.Xml.Serialization;

public class XmlHelper
{
    public static T[] CollectionDeserializer<T>(string objectsAsString, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);

        XmlSerializer serializer = new XmlSerializer(typeof(T[]), root);

        using StringReader reader = new StringReader(objectsAsString);

        return serializer.Deserialize(reader) as T[];
    }

    public static T Deserializer<T>(string objectAsString, string rootName)
        where T : class
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);

        XmlSerializer serializer = new XmlSerializer(typeof(T), root);

        using StringReader reader = new StringReader(objectAsString);

        return serializer.Deserialize(reader) as T;
    }
}