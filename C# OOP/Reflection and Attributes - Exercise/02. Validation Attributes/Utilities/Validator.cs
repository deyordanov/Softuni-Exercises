namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            Console.WriteLine(typeof(MyValidationAttribute));

            PropertyInfo[] properties = type
                .GetProperties()
                .Where(p => p.CustomAttributes
                    .Any(c => typeof(MyValidationAttribute)
                        .IsAssignableFrom(c.AttributeType)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(c => typeof(MyValidationAttribute)
                        .IsAssignableFrom(c.GetType()))
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.isValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
