namespace Serialization.Serializers;

using System.Text.Json;

public static class JSON
{
    public static T DeepCopyJSON<T>(T input)
    {
        string jsonString = JsonSerializer.Serialize(input);

        return JsonSerializer.Deserialize<T>(jsonString);
    }
}