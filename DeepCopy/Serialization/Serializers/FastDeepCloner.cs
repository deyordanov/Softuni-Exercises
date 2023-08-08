namespace Serialization.Serializers;

using global::FastDeepCloner;

public static class FastDeepCloner
{
    public static T DeepCopyFastDeepCloner<T>(T input)
    {
        return (T)DeepCloner.Clone(input);
    }
}