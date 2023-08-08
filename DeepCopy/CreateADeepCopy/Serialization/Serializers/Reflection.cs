namespace Serialization.Serializers;

using System.Reflection;

public static class Reflection
{
    public static T DeepCopyReflection<T>(T input)
    {
        Type type = input.GetType();
        PropertyInfo[] properties = type.GetProperties();

        T objectClone = (T)Activator.CreateInstance(type);

        foreach(PropertyInfo property in properties)
        {
            if (property.CanWrite)
            {
                object value = property.GetValue(input);
                if (value != null && value.GetType().IsClass && !value.GetType().FullName.StartsWith("System."))
                {
                    property.SetValue(objectClone, DeepCopyReflection(value));
                }
                else
                {
                    property.SetValue(objectClone, value);
                }
            }
        }

        return objectClone;
    }
}