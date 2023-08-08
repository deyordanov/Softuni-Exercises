namespace Serialization.Serializers;

using System.Runtime.Serialization;

public static class DataContract
{
    public static T DeepCopyDataContract<T>(T input)
    {
        using MemoryStream stream = new MemoryStream();

        DataContractSerializer serializer = new DataContractSerializer(typeof(T));
        serializer.WriteObject(stream, input);
        stream.Position = 0;

        return (T)serializer.ReadObject(stream);
    }
}